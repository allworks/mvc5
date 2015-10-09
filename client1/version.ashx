<%@ WebHandler Language="C#" Class="Version" %>

using System.Web;

public class Version : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("1.2.3.4");
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
