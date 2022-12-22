using ShoesEcomm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesEcomm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View(Product.GetProducts(false));
        }

        public ActionResult Admin()
        {
            return View(Product.GetProducts(true));
        }

        
    }
}