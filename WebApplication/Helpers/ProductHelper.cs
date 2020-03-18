using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Helpers
{
    public static class ProductHelper
    {
        public static List<ProductModel> GetProducts()
        {
            List<ProductModel> list = new List<ProductModel>();
            try
            {
                using (var db = new ProductDb())
                {
                    var products = db.Products.ToList();
                    if (products != null && products.Any())
                    {
                        list = products.Select(m => new ProductModel(m)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public static ProductModel GetProductModelById(int id)
        {
            ProductModel ProductModel = null;
            try
            {
                using (var db = new ProductDb())
                {
                    var product = db.Products.Find(id);
                    if (product != null)
                    {
                        ProductModel = new ProductModel(product);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ProductModel;

        }
        public static Result DeleteProduct(int Id)
        {

            Result result = new Result();
            try
            {
                using (var db = new ProductDb())
                {
                    var ProductModel = db.Products.Find(Id);
                    if (ProductModel != null)
                    {
                        db.Entry(ProductModel).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result = new Result(ex);
            }
            return result;
        }
        public static Result SaveProduct(ProductModel model)
        {
            Result result = new Result();
            try
            {
                Product product = new Product();
                product.ProductModelToProductMapExtension(model);
               
                using (var db = new ProductDb())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = new Result(new Exception("Unable to add new product"));
            }

            return result;
        }

        public static Result EditProduct(ProductModel model)
        {
            Result result = new Result();
            try
            {
                using(var db = new ProductDb())
                {
                    var item = db.Products.Find(model.ProductID);
                    if(item != null)
                    {
                        item.ProductModelToProductMapExtension(model);

                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                result = new Result( new Exception("Unable to edit Product"));
            }

            return result;
        }
        public static Result Delete(int id)
        {
            Result result = new Result();
            try
            {
                using (var db = new ProductDb())
                {
                    var item = db.Products.Find(id);
                    if (item != null)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result = new Result(new Exception("Unable to delete Product"));
            }
            return result;
        }

    }
}