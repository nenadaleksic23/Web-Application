using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Context;
using WebApplication.Helpers;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Delete(int ProductId)
        {
            Result result = ProductHelper.DeleteProduct(ProductId);
            if (result.IsSuccess)
            {
                return Json(new { Succeded = true,  CallBack = "RefreshProducts"  });
            }
            else
            {
                return Json(new { Succeded = false, CallBack = "DisplayError", Error = result.Error });
            }
        }
        public ActionResult CreationForm()
        {
            Product product = new Product();
            return PartialView("~/Views/Home/Partial/_CreationForm.cshtml", product);
        }
    }
}