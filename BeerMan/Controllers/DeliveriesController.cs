using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class DeliveriesController : Controller
    {
        // GET: Deliveries
        public ActionResult Index()
        {
            return View();
        }
    }
}