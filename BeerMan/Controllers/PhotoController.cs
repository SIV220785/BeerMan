using BeerMan.Models;
using Ninject;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    [RoutePrefix("Photo")]
    public class PhotoController : Controller
    {
        [Inject]
        public BeermanContext DB { get; set; }

        [Route("Index")]
        public ActionResult Index()
        {
            var photos = DB.Photos.ToList();
            return View(photos);
        }

        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // domain/create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Photo photo, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                photo.Image = imageData;


                DB.Photos.Add(photo);
                DB.SaveChanges();

                return RedirectToAction("index", "photo");
            }
            return View(photo);
        }
    }
}