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
            return View("~/Views/Home/Index.cshtml",models);
        }
        public ActionResult Delete(int productId)
        {
            Result result = ProductHelper.DeleteProduct(productId);
         
            return Index();
        }
        public ActionResult CreationForm()
        {
            ProductModel product = new ProductModel();
            return PartialView("ProductForm", product);
        }

        public ActionResult Save(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ProductID > 0)
                {
                    ProductHelper.EditProduct(model);
                }
                else
                {
                    ProductHelper.SaveProduct(model);
                }
                return Index();
            }
            else
            {
                //In case of some modelstate errors and stuff when server validation needed
                return Edit(model.ProductID);
            }
            
        }
        public ActionResult Edit(int productId)
        {
            ProductModel product = ProductHelper.GetProductModelById(productId);
            return View("ProductForm", product);
        }
       

    }
}