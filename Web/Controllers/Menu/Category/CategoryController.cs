using Easy.Domain.Application;
using StudyDome.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers.Menu.Category
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        //public void Save(string name,int sort,int restaurantId)
        //{
           
        //    Redirect("/Category/Show");
        //}

        public ActionResult Show()
        {
            string name = "lyp";
            int sort = 1;
            int restaurantId = 1;
            var @return = ApplicationRegistry.Category.Add(name, sort, restaurantId);
            var value = @return.Result(new ReturnContext() { SystemId = "app" });

            //var @return1 = ApplicationRegistry.Category.Select(restaurantId);
            var value1 = @return.Result(new ReturnContext() { SystemId = "app" });      
            //var result=value.      
            return View(value1);
        }
    }
}