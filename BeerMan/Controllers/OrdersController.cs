using BeerMan.Models;
using Ninject;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class OrdersController : Controller
    {
        [Inject]
        public BeermanContext DB { get; set; }
        // GET: Orders
        public ActionResult Index()
        {
            var orders = DB.Orders.Where(x => x.AspNetUsers.UserName.Equals(User.Identity.Name)).ToList();
            return View(orders);
        }


        public ActionResult Create()
        {
            ProductsModel productsModel = new ProductsModel
            {
                Foods = DB.Foods.ToList(),
                Drinks = DB.Drinks.ToList()
            };
            return View(productsModel);
        }

        [HttpPost]
        public ActionResult Create(CreateOrderModel model)
        {
            if (ModelState.IsValid)
            {
                var foods = DB.Foods.ToList();
                var drinks = DB.Drinks.ToList();
                var user = DB.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
                Order order = new Order();

                foreach (var food in foods)
                {
                    for (int i = 0; i < model.Foods.Count(); i++)
                    {
                        if (food.Id == model.Foods[i])
                        {
                            order.Cost += food.Cost * model.CountFoods[i];
                            food.Count = model.CountFoods[i];
                            order.Foods.Add(food);
                        }
                    }
                }
                foreach (var drink in drinks)
                {
                    for (int i = 0; i < model.Drinks.Count(); i++)
                    {
                        if (drink.Id == model.Drinks[i])
                        {
                            order.Cost += drink.Cost * model.CountDrinks[i];
                            drink.Count = model.CountDrinks[i];
                            order.Drinks.Add(drink);
                        }
                    }
                }

                order.IsPayment = false;
                order.CreateDate = DateTime.Now;
                user.Orders.Add(order);
                DB.AspNetUsers.Attach(user);
                DB.Entry(user).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("index", "orders");
            }
            return View(model);
        }

        public ActionResult PayOrder()
        {
            var user = DB.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
            return View(user);
        }

        [HttpPost]
        public ActionResult PayOrder(PayOrderModel payOrderModel)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = new Transaction();
                Wallet wallet = new Wallet();
                var user = DB.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));
                foreach (var order in user.Orders)
                {
                    for (int i = 0; i < payOrderModel.Orders.Count(); i++)
                    {
                        if (order.Id == payOrderModel.Orders[i])
                        {
                            if (user.Wallet.Coins >= order.Cost)
                            {
                                transaction.Type = (TypeCost)payOrderModel.TypePaymet[i];
                                transaction.TransactionDate = DateTime.Now;
                                transaction.Amount = order.Cost;
                                user.Wallet.Coins -= order.Cost;
                                break;
                            }
                        }
                    }
                }

                user.Wallet.Transactions.Add(transaction);
                DB.AspNetUsers.Attach(user);
                DB.Entry(user).State = EntityState.Modified;
                DB.SaveChanges();                
                return RedirectToAction("index", "orders");
            }

            return View(payOrderModel);
        }

    }
}