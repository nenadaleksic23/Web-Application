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
            return View(products);
        }
        public ActionResult Delete(int productId)
        {
            JsonHelper.DeleteProduct(productId);
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            else
            {
                //In case of some modelstate errors and stuff when  complex server validation needed
                return ProductForm(model.ProductID);
            }
           
        }

        public ActionResult ProductForm(int? productId)
        {
            ProductModel product = new ProductModel();
            if (productId.HasValue && productId.Value > 0)
            {
                product = JsonHelper.GetProductById(productId.Value);
            }
            return PartialView("ProductForm", product);
        }



    }
}