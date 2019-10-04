using BeerMan.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class WalletController : Controller
    {
        [Inject]
        public BeermanContext _bContext { get; set; }

        
        // GET: Wallet
        public ActionResult Index()
        {
            var users = _bContext.AspNetUsers.ToList();
            return View(users);
        }
    }
}