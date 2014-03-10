using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaDemo.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Event/
        public ActionResult EventList()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        public ActionResult EventDetail()
        {
            return View();
        }
	}
}