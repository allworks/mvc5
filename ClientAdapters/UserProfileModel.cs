namespace ClientAdapters
{
    public class UserProfileModel
    {
        public string Email { get; set; }
        public string Company { get; set; }
        public string Account { get; set; }
        public string[] Classes { get; set; }
        public string[] Roles { get; set; }
        public string[] Groups { get; set; }

    }
}