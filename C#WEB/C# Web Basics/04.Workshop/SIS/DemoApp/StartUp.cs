namespace DemoApp
{
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.MvcFramework;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/Users/Login", DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/Contact", Contact));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));
        }

        public void ConfigureServices()
        {
        }

        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");

            return new FileResponse(byteContent, "image/x-icon");
        }

        private static HttpResponse Contact(HttpRequest request)
        {
            return new HtmlResponse("<h1>Contact</h1>");
        }

        public static HttpResponse Index(HttpRequest request)
        {
            var username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";
            return new HtmlResponse($"<h1>Home page. Hello, {username} </h1>");
        }

        public static HttpResponse Login(HttpRequest request)
        {
            request.SessionData["Username"] = "Pesho";
            return new HtmlResponse("<h1>Login</h1>");
        }

        public static HttpResponse DoLogin(HttpRequest request)
        {
            return new HtmlResponse("<h1>Login Page Form</h1>");
        }
    }
}
