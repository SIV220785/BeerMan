using BeerMan.Models;
using BeerMan.Validation;
using System.Web.Mvc;

namespace BeerMan.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post (Wallet model)
        {
            var validator = new DemoValidation();
            var valadatorResaul = validator.Validate(model);
            
                if (!valadatorResaul.IsValid)
            { 
                
            }     
            return View("Index");
        }
    }
}