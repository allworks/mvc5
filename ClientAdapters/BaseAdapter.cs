using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ClientAdapters
{
    public abstract class BaseAdapter : IClient
    {
        public string LoginUrl { get; set; }

        public abstract ClientResponse GetProfile(string email, string password);

        protected static ClientResponse Post(string url, NameValueCollection reqParms)
        {
            var response = new ClientResponse();
            using (var client = new WebClient())
            {
                try
                {
                    var respBytes = client.UploadValues(url, "POST", reqParms);
                    var json = Encoding.UTF8.GetString(respBytes);
                    response = JsonConvert.DeserializeObject<ClientResponse>(json);
                }
                catch (Exception e)
                {
                    response.Error = e.Message;
                }
            }
            return response;
        }
    }
}