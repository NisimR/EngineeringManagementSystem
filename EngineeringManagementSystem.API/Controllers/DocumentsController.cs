using System.IO;
using EngineeringManagementSystem.API.Data;
using EngineeringManagementSystem.API.DTOs;
using EngineeringManagementSystem.API.Models;
using EngineeringManagementSystem.API.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;




namespace EngineeringManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly EngineeringManegementDbContext _context;

        public DocumentsController(EngineeringManegementDbContext context)
        {
            _context = context;
        }


        // helper function – מחפש לפי שם
        private int? GetUserIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var user = _context.Users.FirstOrDefault(u => u.FullName == name);
            return user?.UserId;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetById(int id)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null)
                return NotFound();

            return doc;
        }

        [HttpGet("byProject/{projectId}")]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetByProject(int projectId)
        {
            try
            {
                var docs = await _context.Documents
                    .Where(d => d.EngProjId == projectId)
                    .Select(d => new DocumentDTO
                    {
                        DocumentId = d.DocumentId,

                        DocName = d.DocName,
                        FileName = d.DocName,
                        PathDoc = d.PathDoc,
                        IsReleased = d.IsReleased,
                        Rev = d.Rev.ToString(),
                        PartNumberDoc = d.PartNumberDoc,
                        ReleaseDate = d.ReleaseDate,

                        // שימוש בשמות מחברים אם קיימים
                        Author = _context.Users.FirstOrDefault(u => u.UserId == d.AuthorId) != null
                                    ? _context.Users.FirstOrDefault(u => u.UserId == d.AuthorId).FullName
                                    : null,

                        Reviewer = d.ReviewerId != null && _context.Users.FirstOrDefault(u => u.UserId == d.ReviewerId) != null
                                    ? _context.Users.FirstOrDefault(u => u.UserId == d.ReviewerId).FullName
                                    : null,

                        Approver = d.ApproverId != null && _context.Users.FirstOrDefault(u => u.UserId == d.ApproverId) != null
                                    ? _context.Users.FirstOrDefault(u => u.UserId == d.ApproverId).FullName
                                    : null
                    })
                    .ToListAsync();

                return Ok(docs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בשרת: {ex.Message}");
            }
        }

        private async Task<int> GetNextPartNumberAsync()
        {
            int max = await _context.Documents
                .OrderByDescending(d => d.PartNumberDoc)
                .Select(d => d.PartNumberDoc)
                .FirstOrDefaultAsync();

            return max == 0 ? 100000000 : max + 1;
        }


        // POST: api/Documents
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentRequest request)
        {
            var doc = new Document
            {
                PartNumberDoc = await GetNextPartNumberAsync(),
                PathDoc = request.PathDoc,
                DocName = request.DocName,
                Rev = 'A',
                AuthorId = GetUserIdByName(request.AuthorName),
                ReviewerId = GetUserIdByName(request.ReviewerName),
                ApproverId = GetUserIdByName(request.ApproverName),
                AuthorSigned = false,
                ReviewerSigned = false,
                ApproverSigned = false,
                IsReleased = false,
                ReleaseDate = null,
                EngProjId = request.EngProjId

            };

            _context.Documents.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = doc.DocumentId }, doc);
        }

        [HttpPost("{id}/createNewRevision")]
        public async Task<IActionResult> CreateNewRevision(int id, [FromBody] DocumentRequest request)
        {
            var existingDoc = await _context.Documents.FindAsync(id);
            if (existingDoc == null)
                return NotFound("מסמך לא נמצא.");

            // חישוב מהדורה חדשה
            char nextRev = existingDoc.Rev >= 'A' && existingDoc.Rev < 'Z'
                ? (char)(existingDoc.Rev + 1)

                : throw new Exception("המהדורה הגיעה ל-Z ואי אפשר להמשיך.");

            // יצירת שם קובץ ונתיב חדש
            var newFileName = $"{existingDoc.DocName}_{nextRev}.docx";
            var newFilePath = Path.Combine(Path.GetDirectoryName(existingDoc.PathDoc), newFileName);

            // שלב 1: מציאת המספר הכי גבוה הקיים
            int nextPartNumber = await _context.Documents
                .OrderByDescending(d => d.PartNumberDoc)
                .Select(d => d.PartNumberDoc)
                .FirstOrDefaultAsync();

            nextPartNumber = nextPartNumber == 0 ? 100000000 : nextPartNumber + 1;

            var newDoc = new Document
            {
                DocName = existingDoc.DocName,
                PartNumberDoc = nextPartNumber,
                Rev = nextRev,
                PathDoc = newFilePath,
                AuthorId = GetUserIdByName(request.AuthorName),
                ReviewerId = GetUserIdByName(request.ReviewerName),
                ApproverId = GetUserIdByName(request.ApproverName),
                AuthorSigned = false,
                ReviewerSigned = false,
                ApproverSigned = false,
                IsReleased = false,
                ReleaseDate = null,
                EngProjId = existingDoc.EngProjId
            };

            _context.Documents.Add(newDoc);
            await _context.SaveChangesAsync();

            try
            {
                System.IO.File.Copy(existingDoc.PathDoc, newDoc.PathDoc, overwrite: true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בהעתקת הקובץ: {ex.Message}");
            }

            return Ok(new
            {
                Message = $"מהדורה {nextRev} נוצרה בהצלחה",
                newId = newDoc.DocumentId,
                newPath = newDoc.PathDoc
            });
        }

        [HttpPost("{id}/startCycle/{userId}")]
        public async Task<IActionResult> StartDocumentCycle(int id, int userId)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null) return NotFound("Document not found.");

            // רק אם המשתמש הוא המחבר של המסמך – אפשר להתחיל את הסבב
            /*if (doc.AuthorId != userId)
                return Forbid("רק מחבר המסמך יכול לשחרר אותו.");*/

            if (doc.AuthorSigned)
                return BadRequest("הסבב כבר התחיל.");

            doc.AuthorSigned = true;
            await _context.SaveChangesAsync();
            return Ok("הסבב התחיל. נחתם על ידי העורך.");
        }




        [HttpPost("{id}/approve/{userId}")]
        public async Task<IActionResult> ApproveDocument(int id, int userId)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null) return NotFound();

            if (doc.AuthorId == userId && !doc.AuthorSigned)
            {
                doc.AuthorSigned = true;
            }
            else if (doc.ReviewerId == userId && doc.AuthorSigned && !doc.ReviewerSigned)
            {
                doc.ReviewerSigned = true;
            }
            else if (doc.ApproverId == userId && doc.AuthorSigned && doc.ReviewerSigned && !doc.ApproverSigned)
            {
                doc.ApproverSigned = true;
                doc.IsReleased = true;
                doc.ReleaseDate = DateTime.Now;
            }
            else
            {
                return Forbid("אין לך הרשאה או שהחתימה כבר בוצעה.");
            }

            await _context.SaveChangesAsync();
            return Ok("המסמך עודכן בהצלחה.");
        }


        [HttpGet("pendingForUser/{userId}")]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetPendingForUser(int userId)
        {
            var docs = await _context.Documents
                .Where(d =>
                    (d.AuthorId == userId && !d.AuthorSigned) ||
                    (d.ReviewerId == userId && d.AuthorSigned && !d.ReviewerSigned) ||
                    (d.ApproverId == userId && d.AuthorSigned && d.ReviewerSigned && !d.ApproverSigned))
                .Select(d => new DocumentDTO
                {
                    DocumentId = d.DocumentId,
                    DocName = d.DocName,
                    PathDoc = d.PathDoc,
                    IsReleased = d.IsReleased,
                    PartNumberDoc = d.PartNumberDoc,
                    Rev = d.Rev.ToString()
                }).ToListAsync();

            return Ok(docs);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentRequest request)
        {
            var existingDoc = await _context.Documents.FindAsync(id);
            if (existingDoc == null)
                return NotFound();

            // ⚠️ אם משוחרר – צור מסמך חדש עם Rev מתקדם
            if (existingDoc.IsReleased)
            {
                // חשב מהדורה חדשה – A → B → C ...
                char nextRev = existingDoc.Rev >= 'A' && existingDoc.Rev < 'Z'
                    ? (char)(existingDoc.Rev + 1)
                    : throw new Exception("המהדורה הגיעה ל-Z ואי אפשר להמשיך.");

                var newFileName = $"{existingDoc.DocName}_{nextRev}.docx";
                var newFilePath = Path.Combine(Path.GetDirectoryName(existingDoc.PathDoc), newFileName);

                var newDoc = new Document
                {
                    DocName = existingDoc.DocName,
                    PartNumberDoc = existingDoc.PartNumberDoc,
                    Rev = nextRev,
                    PathDoc = newFilePath,
                    AuthorId = GetUserIdByName(request.AuthorName),
                    ReviewerId = GetUserIdByName(request.ReviewerName),
                    ApproverId = GetUserIdByName(request.ApproverName),
                    AuthorSigned = false,
                    ReviewerSigned = false,
                    ApproverSigned = false,
                    IsReleased = false,
                    ReleaseDate = null,
                    EngProjId = existingDoc.EngProjId
                };

                // שמירה למסד
                _context.Documents.Add(newDoc);
                await _context.SaveChangesAsync();

                // העתקת הקובץ המקורי
                try
                {
                    System.IO.File.Copy(existingDoc.PathDoc, newDoc.PathDoc, overwrite: true);

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"שגיאה בהעתקת הקובץ: {ex.Message}");
                }

                return Ok(new { Message = $"מהדורה חדשה {nextRev} נוצרה בהצלחה", NewId = newDoc.DocumentId });

            }

            // ❗ לא משוחרר – עדכון רגיל
            existingDoc.DocName = request.DocName;
            existingDoc.PartNumberDoc = request.PartNumberDoc;
            existingDoc.PathDoc = request.PathDoc;
            existingDoc.AuthorId = GetUserIdByName(request.AuthorName);
            existingDoc.ReviewerId = GetUserIdByName(request.ReviewerName);
            existingDoc.ApproverId = GetUserIdByName(request.ApproverName);



            await _context.SaveChangesAsync();
            return Ok(new { Message = "המסמך עודכן בהצלחה" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null)
                return NotFound("המסמך לא נמצא.");

            // ❗ אם המסמך משוחרר – רק Admin יכול למחוק
            var role = User.FindFirst("role")?.Value;
            if (doc.IsReleased && role != "Admin")
                return Forbid("רק אדמין יכול למחוק מסמך ששוחרר.");

            _context.Documents.Remove(doc);
            await _context.SaveChangesAsync();
            return Ok("המסמך נמחק בהצלחה.");
        }




    }
}