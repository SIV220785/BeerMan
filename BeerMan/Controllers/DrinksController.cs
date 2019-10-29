using BeerMan.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class DrinksController : Controller
    {
        [Inject]
        public BeermanContext DB { get; set; }

        // GET: Food
        public ActionResult Index()
        {
            var drinks = DB.Drinks.ToList();
            return View(drinks);
        }

        public ActionResult AddDrink()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDrink(Drink drink, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                drink.Photo.Image = imageData;


                DB.Drinks.Add(drink);
                DB.SaveChanges();

                return RedirectToAction("index", "drinks");
            }
            return View(drink);
        }
    }
}