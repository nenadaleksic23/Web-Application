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
        public static Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                using (var db = new ProductDb())
                {
                    product = db.Products.Find(id);
                }
            }
            catch(Exception ex)
            {
                
            }
            return product;

        }
        public static Result DeleteProduct(int Id)
        {

            Result result = new Result();
            try
            {
                using (var db = new ProductDb())
                {
                    var product = db.Products.Find(Id);
                    if(product != null)
                    {
                        db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                result = new Result(ex);
            }
            return result;
        }

    }
}