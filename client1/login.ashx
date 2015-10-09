<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Linq;
using System.Web;

public class Login : IHttpHandler {
    
    const string ResponseFormat = "{{ \"Error\": \"{0}\", \"Profile\": {1} }}";

    public void ProcessRequest (HttpContext context)
    {
        var email = context.Request.Form["email"];
        var error = "";
        var results = "{}";

        context.Response.ContentType = "application/json";
        try
        {
            results = Profiles.Single(p => p.Contains(email));
        }
        catch (Exception ex)
        {
            error = ex.Message;
            context.Response.StatusDescription = "Profile not found";
            context.Response.StatusCode = 400;
        }
        var response = string.Format(ResponseFormat, error, results);
        context.Response.Write(response);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    private static readonly string Test1 = @"{
 'LoginUrl': 'http://localhost/client1/login.ashx',
 'Email': 'test1@abc.com',
 'Company': 'abc',
 'Account': 'test1',
 'Password': 'Test123!',
 'Classes': [ 'class1', 'class2' ],
 'Roles': [ 'role1', 'role2' ],
 'Groups': [ 'group1', 'group2' ]
 }".Replace('\'', '"');

    private static readonly string Test2 = @"{
'LoginUrl': 'http://localhost/client1/login.ashx',
'Email': 'test1@xyz.com',
'Company': 'xyz',
'Account': 'test1',
'Password': 'Test123!',
'Classes': [ 'class2', 'class3' ],
'Roles': [ 'role2', 'role3' ],
'Groups': [ 'group2', 'group3' ]
}".Replace('\'', '"');

    private static readonly string Test3 = @"{
'LoginUrl': 'http://localhost/client1/login.ashx',
'Email': 'test2@xyz.com',
'Company': 'xyz',
'Account': 'test2',
'Password': 'Test123!',
'Classes': [ 'class3', 'class4' ],
'Roles': [ 'role3', 'role4' ],
'Groups': [ 'group3', 'group4' ]
}".Replace('\'', '"');
    
    static readonly string[] Profiles = { Test1, Test2, Test3 };
}