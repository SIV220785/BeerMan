using BeerMan.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Controls;

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
            var foods = DB.Foods.ToList();
            return View(foods);
        }

        [HttpPost]
        public ActionResult Create(CreateOrderModel model)
        {
            if (ModelState.IsValid)
            {
                var foods = DB.Foods.ToList();
                var user = DB.AspNetUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name));               
                Order order = new Order();

                foreach (var item in foods)
                {
                    for (int i = 0; i < model.Pizzas.Count(); i++)
                    {
                        if (item.Id == model.Pizzas[i])
                        {
                            order.Cost += item.Cost * model.Count[i];
                            item.Count = model.Count[i];
                            order.Foods.Add(item);
                        }
                    }
                }

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
            return View(user.Orders.ToList());
        }

    }
}