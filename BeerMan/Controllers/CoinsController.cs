using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class CoinsController : Controller
    {
        // GET: Coins
        public ActionResult Index()
        {
            return View();
        }
    }
}