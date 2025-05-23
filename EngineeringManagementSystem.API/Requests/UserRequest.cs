namespace EngineeringManagementSystem.API.Requests
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; } // סיסמה גלויה – תועבר להאשינג
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
