using System;
using System.Net;
using System.Text;
using ClientAdapters;
using Newtonsoft.Json;
using NUnit.Framework;
using NameValueCoolection = System.Collections.Specialized.NameValueCollection;
using UserProfileModel = MVC5.Models.UserProfileModel;

namespace MVC5.Tests
{
    [TestFixture]
    public class TheAppTest
    {
        private const string Url = "http://localhost/theapp";

        [Test]
        public void GetProfoleShouldSucceed()
        {
            var adapter = new DefaultAdapter(Url);
            var resp = adapter.GetProfile("test1@abc.com", "Test123!");
            Assert.That(resp, Is.Not.Null);

            var profile = resp.Profile;
            Assert.That(profile.Account, Is.EqualTo("test1"));
            Assert.That(profile.Company, Is.EqualTo("abc"));
        }


        [Test]
        public void BadRequestShouldFail()
        {
            var adapter = new DefaultAdapter(Url);
            var resp = adapter.GetProfile("xxx@xxx.com", "Test123!");
            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Error, Is.Not.Empty);
        }

        private static string Post(NameValueCoolection reqParms)
        {
            string respBody = null;
            using (var client = new WebClient())
            {

                try
                {
                    var respBytes = client.UploadValues(Url, "POST", reqParms);
                    respBody = Encoding.UTF8.GetString(respBytes);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return respBody;
        }

    }
}
