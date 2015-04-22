using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace HopNguyenCms
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    HttpApplication app = (HttpApplication)sender;
        //    string acceptEncoding = app.Request.Headers["Accept-Encoding"];
        //    System.IO.Stream prevUncompressedStream = app.Response.Filter;

        //    if (acceptEncoding == null || acceptEncoding.Length == 0)
        //        return;

        //    acceptEncoding = acceptEncoding.ToLower();

        //    if (acceptEncoding.Contains("gzip"))
        //    {
        //        // gzip
        //        app.Response.Filter = new System.IO.Compression.GZipStream(prevUncompressedStream,
        //                                                                   System.IO.Compression.CompressionMode.
        //                                                                       Compress);
        //        app.Response.AppendHeader("Content-Encoding",
        //                                  "gzip");
        //    }
        //    else if (acceptEncoding.Contains("deflate"))
        //    {
        //         //defalte
        //        app.Response.Filter = new System.IO.Compression.DeflateStream(prevUncompressedStream,
        //                                                                      System.IO.Compression.CompressionMode.
        //                                                                          Compress);
        //        app.Response.AppendHeader("Content-Encoding",
        //                                  "deflate");
        //    }
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}