namespace CommentProject.Models.AppUserViewModels
{
    public class SMTPConfigModel
    {
        public string SenderAdress { get; set; }
        public string SenderDisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string EnableSSL { get; set; }
        public string UseDefaultCredentials { get; set; }
        public string IsBodyHtml { get; set; }
    }
}
