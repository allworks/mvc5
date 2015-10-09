using Newtonsoft.Json;

namespace ClientAdapters
{
    public class ClientResponse
    {
        public string Error { get; set; }
        public UserProfileModel Profile { get; set; }

        public string GetProfileInJson()
        {
            return JsonConvert.SerializeObject(Profile, Formatting.None);
        }
    }
}