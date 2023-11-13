namespace UserPlatform.ApplicationCore.Models.Response
{
    public class ChangePasswordResponse
    {
        public string TempPassword { get; set; }
        public string Token { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}