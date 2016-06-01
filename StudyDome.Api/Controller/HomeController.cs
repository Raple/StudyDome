using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudyDome.Api.Controller
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }
    }
}
