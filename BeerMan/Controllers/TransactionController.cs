using BeerMan.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class TransactionController : Controller
    {
        [Inject]
        public BeermanContext Db { get; set; }
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTransaction(Transaction transaction)
        {
            var user = Db.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
            Transaction _transaction = new Transaction()
            {
                Amount = transaction.Amount,
                Type = transaction.Type,
                TransactionDate = DateTime.Now
            };

            if (user.Wallet.Transactions.Count == 0)
            {
                List<Transaction> transactions = new List<Transaction>
                {
                    _transaction
                };
                user.Wallet.Transactions = transactions;
            }
            else
            {
                user.Wallet.Transactions.Add(_transaction);
            }
            Db.AspNetUsers.Attach(user);
            Db.Entry(user).State = EntityState.Modified;
            Db.SaveChanges();

            return View();
        }


    }
}