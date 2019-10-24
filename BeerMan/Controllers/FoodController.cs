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
    public class FoodController : Controller
    {
        [Inject]
        public BeermanContext DB { get; set; }

        // GET: Food
        public ActionResult Index()
        {
            var foods = DB.Foods.ToList();
            return View(foods);
        }

        public ActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFood(Food food, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                food.Photo.Image = imageData;


                DB.Foods.Add(food);
                DB.SaveChanges();

                return RedirectToAction("index", "food");
            }
            return View(food);
        }
    }
}