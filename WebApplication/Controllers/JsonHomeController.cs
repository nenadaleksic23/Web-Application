using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class JsonHomeController : Controller
    {
        // GET: JsonHome
        public ActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();
            products = JsonHelper.GetProductsFromFile();
            return View("~/Views/Home/Index.cshtml", products);
        }
        public ActionResult Delete(int productId)
        {
            JsonHelper.DeleteProduct(productId);
            return Index();
        }

        public ActionResult Save(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.ProductID > 0)
                {
                    JsonHelper.EditProduct(model);
                }
                else
                {
                    JsonHelper.SaveProductToFile(model);
                }
            }
            return Index();
        }

        public ActionResult CreationForm()
        {
            ProductModel product = new ProductModel();
            return PartialView("ProductForm", product);
        }
        public ActionResult Edit(int productId)
        {
            ProductModel product = JsonHelper.GetProductById(productId);
            return PartialView("ProductForm", product);
        }



    }
}