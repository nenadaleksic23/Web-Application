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
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<ProductModel> models = ProductHelper.GetProducts();
            return View(models);
        }
        public ActionResult Delete(int productId)
        {
            Result result = ProductHelper.DeleteProduct(productId);
            //if(result.IsSuccess) {do some great stuff with View and fancy JS } else{ Huston we have a problem !}

            return RedirectToAction("Index");
        }

        public ActionResult ProductForm(int? productId)
        {
            ProductModel product = new ProductModel();
            if(productId.HasValue && productId.Value > 0)
            {
                product = ProductHelper.GetProductModelById(productId.Value);
            }
            return PartialView("ProductForm", product);
        }

        public ActionResult Save(ProductModel model)
        {
            Result result = new Result();
            if (ModelState.IsValid)
            {
                if (model.ProductID > 0)
                {
                    result = ProductHelper.EditProduct(model);
                }
                else
                {
                    result = ProductHelper.SaveProduct(model);
                }
                //For this I should make some frontend setup for user friendly messages fallbacks etc
                //if (result.IsSuccess) { DOSomeGreatStuff() }else{ ComeOnYouCanDoIt() }
                return RedirectToAction("Index");
            }
            else
            {
                //In case of some modelstate errors and stuff when server validation needed
                return ProductForm(model.ProductID);
            }
            
        }
    }
}