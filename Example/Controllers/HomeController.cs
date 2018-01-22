using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Models;
using Microsoft.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.Controllers
{
    public class CustomFilter : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            System.Diagnostics.Debug.WriteLine("OnActionExecuting called in custom filter");
            System.Diagnostics.Debug.WriteLine(string.Format("Current actions method is {0}", context.HttpContext.Request.Method));

            if (context.ActionArguments.ContainsKey("param1"))
                context.ActionArguments["param1"] = "i reset it in a filter";
            else
                context.ActionArguments.Add("param1", "i added it in a filter");

            base.OnActionExecuting(context);
        }
    }

    [CustomFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(
                @"
                <div>This is some valid HTML</div>
                <form action='/home/post1' method='POST'>
                    <label>Enter some text</label>
                    <input type='text' name='param1' />
                    <input type='submit' value='next' />
                </form>
                ",
                new MediaTypeHeaderValue("text/html")
            );
        }

        [HttpPost]
        public IActionResult Post1(string param1)
        {
            System.Diagnostics.Debug.WriteLine(param1);
            string content = @"
                                <form action='/post2' method='POST'>
                                    <input type='hidden' name='original' value='{0}' />
                                    <label>Enter some more text to append to <strong>{0}</strong></label>
                                    <input type='text' name='more' />
                                    <input type='submit' value='finish' />
                                </form>
                             ";
            return Content(string.Format(content, param1), new MediaTypeHeaderValue("text/html"));
        }

        [HttpPost]
        [HttpGet]
        [Route("/post2")]
        public IActionResult Post2(string original, string more)
        {
            StringBuilder builder = new StringBuilder("<div>Here are the values you submitted:<br />");
            foreach(var v in Request.Query)
            {
                builder.Append(string.Format("From query: {0}={1}<br />", v.Key, v.Value));
            }
            if (Request.Method == "POST")
            {
                foreach (var v in Request.Form)
                {
                    builder.Append(string.Format("From form-data: {0}={1}<br />", v.Key, v.Value));
                }
            }

            if (!String.IsNullOrEmpty(original))
                builder.Append(string.Format("Also passed as parameter 'original': {0}<br/>", original));

            if (!String.IsNullOrEmpty(more))
                builder.Append(string.Format("Also passed as parameter 'more': {0}<br />", more));

            builder.Append("</div>");

            return Content(builder.ToString(), new MediaTypeHeaderValue("text/html"));
        }

        [HttpGet]
        public IActionResult FIlterExample(string param1)
        {
            return Content(string.Format("WIth param1: {0}", param1));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
