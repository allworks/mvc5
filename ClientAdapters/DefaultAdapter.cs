using System.Collections.Specialized;

namespace ClientAdapters
{
    public class DefaultAdapter : BaseAdapter
    {
        public DefaultAdapter(string clientUrl)
        {
            LoginUrl = clientUrl + "/login.ashx";
        }

        public override ClientResponse GetProfile(string email, string password)
        {
            var reqParms = new NameValueCollection
            {
                {"email", email},
                {"password", password}
            };
            var response = Post(LoginUrl, reqParms);
            return response;
        }
    }
}