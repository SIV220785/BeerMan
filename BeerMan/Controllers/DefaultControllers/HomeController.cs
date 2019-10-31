using BeerMan.Models;
using BeerMan.SignalR;
using Microsoft.AspNet.SignalR;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace BeerMan.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public BeermanContext DB { get; set; }
        public ActionResult Index()
        {
            //var users = DB.AspNetUsers.ToList();

            //if (users.Count() != 0)
            //{
            //    Wallet wallet = new Wallet()
            //    {
            //        Coins = 50,
            //    };

            //    users[0].Wallet = wallet;

            //    DB.AspNetUsers.Attach(users[0]);
            //    DB.Entry(users[0]).State= EntityState.Modified;
            //    DB.SaveChanges();
            //}
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void SendMassage(string message)
        {

            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.displayMessage(message);
        }
    }
}