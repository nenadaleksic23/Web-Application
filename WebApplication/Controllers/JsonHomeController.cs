using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class JsonHomeController : BaseController
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
        [HttpPost]
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
                return Index();
            }
            else
            {
                //In case of some modelstate errors and stuff when  complex server validation needed
                return Edit(model.ProductID);
            }
           
        }

        public ActionResult CreationForm()
        {
            ProductModel product = new ProductModel();
            return View("ProductForm", product);
        }
        public ActionResult Edit(int productId)
        {
            ProductModel product = JsonHelper.GetProductById(productId);
            return View("ProductForm", product);
        }



    }
}