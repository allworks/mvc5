using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ClientAdapters
{
    public interface IClient
    {
        string LoginUrl { get; set; }
        ClientResponse GetProfile(string email, string password);
    }
}
