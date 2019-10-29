using BeerMan.Models;
using Ninject;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class WalletController : Controller
    {
        [Inject]
        public BeermanContext Db { get; set; }

        public ActionResult Index()
        {
            var wallet = Db.Wallets.SingleOrDefault(x => x.AspNetUsers.UserName.Equals(User.Identity.Name));            
            return View(wallet);
        }

        [HttpPost]
        public ActionResult AddWallet()
        {

            var user = Db.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
            user.Wallet = new Wallet()
            {
                Coins = 300               
            };
            Db.AspNetUsers.Attach(user);
            Db.Entry(user).State = EntityState.Modified;
            Db.SaveChanges();
            var wallet = Db.Wallets.SingleOrDefault(x => x.AspNetUsers.UserName.Equals(User.Identity.Name));
            return View(wallet);
        }

        [HttpPost]
        public ActionResult CreateWallet()
        {
            var user = Db.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
            user.Wallet = new Wallet()
            {
                Coins = 300
            };
            Db.AspNetUsers.Attach(user);
            Db.Entry(user).State = EntityState.Modified;
            Db.SaveChanges();            
            return RedirectToAction("payorder", "orders");
        }


    }
}