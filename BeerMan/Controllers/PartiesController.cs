using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class PartiesController : Controller
    {
        // GET: Parties
        public ActionResult Index()
        {
            return View();
        }
    }
}