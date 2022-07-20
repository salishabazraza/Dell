namespace WebFront.Core.Helper
{
    public class LoginApiModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public object roleName { get; set; }
        public int roleId { get; set; }
        public int userId { get; set; }
        public string token { get; set; }
    }
}
