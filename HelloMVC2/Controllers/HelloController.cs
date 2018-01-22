using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC2.Controllers
{
    public class HelloController : Controller
    {
        private string CreateMessage(string name, string language)
        {
            string hello = "Hello";
            switch (language)
            {
                case "fr":
                    hello = "Bonjour";
                    break;
                case "pr":
                    hello = "Ola";
                    break;
                case "gr":
                    hello = "Hallo";
                    break;
            }

            return String.Format("{0}, {1}!", hello, name);
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index(string name = "world")
        {
            string content = @" <h1>Hello {0}!</h1>
                                <form method='POST'>
                                    <input name='name' type='text' />
                                    <select name='language'>
                                        <option value='fr'>French</option>
                                        <option value='pr'>Portuguese</option>
                                        <option value='gr'>German</option>
                                        <option value='en'>English</option>
                                    </select>
                                    <input type='submit' />
                                </form>";
            return Content(String.Format(content, name), new MediaTypeHeaderValue("text/html"));
        }

        [HttpPost]
        public IActionResult index(string name, string language)
        {
            int greeting_count = 1;
            if (Request.Cookies.ContainsKey("greeting_count"))
            {
                greeting_count = int.Parse(Request.Cookies["greeting_count"]) + 1;
            }

            Response.Cookies.Append("greeting_count", greeting_count.ToString());
            string content = String.Format("{0}<br/><a href='/goodbye'>Goodbye</a><br/>You have been greeted, {1} time(s).", CreateMessage(name, language), greeting_count);
            return Content(content, new MediaTypeHeaderValue("text/html"));
        }

        [Route("/Goodbye")]
        public IActionResult GoodBye()
        {
            return Redirect("/hello");
        }
    }
}
