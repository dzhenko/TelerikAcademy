using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummatorMVC.Controllers
{
    public class SumController : Controller
    {
        public ActionResult Index(int? val1, int? val2)
        {
            if (val1.HasValue && val2.HasValue)
            {
                this.ViewBag.val1 = val1.Value.ToString();
                this.ViewBag.val2 = val2.Value.ToString();
                this.ViewBag.result = val1.Value + val2.Value;

                return this.View();
            }

            return this.View();
        }
    }
}