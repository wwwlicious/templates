using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Templates;
using ServiceStack.DataAnnotations;
using MyApp.ServiceModel;

namespace MyApp.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }

        public object Any(ViewIndex request) => new PageResult(Request.GetPage("/index"));
        public object Any(ViewContact request) => new PageResult(Request.GetPage("/contact"));
        public object Any(ViewAbout request) => new PageResult(Request.GetPage("/about"));
    }

    [Route("/about")]
    public class ViewAbout
    {
    }

    [Route("/contact")]
    public class ViewContact
    {
    }

    [Route("/index")]
    [FallbackRoute("/{PathInfo*}", Matches="AcceptsHtml")]
    public class ViewIndex
    {
        public string PathInfo { get; set; }
    }
}
