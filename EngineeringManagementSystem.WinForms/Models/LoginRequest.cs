// ⚠️ למה יש כפילות בין המחלקות ב-WinForms ל-API?
// המודל במערכת מבוססת לקוח-שרת חייב להיות מבודד בין צד השרת (API) לצד הלקוח (WinForms):
// כל צד שומר עותק עצמאי של מחלקות ה-DTO (Data Transfer Object),
// כדי לשמור על עקרון ההפרדה (Separation of Concerns) ולא לחשוף מבנה פנימי או תלות הדדית בין המערכות.
// יתרונות הגישה:
// ✅ מאפשר שינוי פנימי בצד השרת מבלי לשבור את הקליינט
// ✅ מאפשר ללקוח להתאים את המחלקות לצרכים מקומיים (תצוגה, ולידציה)
// ✅ מפחית תלות וטעויות בזמן קומפילציה/בנייה
// לכן – מותר ואף מומלץ לשכפל מחלקות DTO בצורה סינכרונית בין הצדדים

// ✅ מחלקה: LoginRequest
// משמשת לשליחת בקשת התחברות מהלקוח (WinForms) לשרת (API)
namespace EngineeringManagementSystem.WinForms.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}