using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Helpers
{
    public static class JsonHelper
    {
        private static string FilePath = HttpContext.Current.Server.MapPath("~/JsonDb/Products.txt");
        private static string GetProductsFromJsonFile()
        {
            string result = string.Empty;
            result = File.ReadAllText(FilePath);

            return result;
        }
        private static void ClearJsonFile(string file)
        {
            File.WriteAllText(file, String.Empty);
        }
        private static Result SaveToFile(List<ProductModel> products)
        {
            Result result = new Result();
            try
            {
                if (products.Any())
                {
                    string parsedJson = JsonConvert.SerializeObject(products, Formatting.Indented);
                    File.WriteAllText(FilePath, parsedJson);
                }
            }
            catch (Exception ex)
            {
                result = new Result(new Exception("Unable to save Products to file"));
            }
            return result;

        }

        public static List<ProductModel> GetProductsFromFile()
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                string result = GetProductsFromJsonFile();
                if (!string.IsNullOrEmpty(result))
                {
                    products = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                }
            }
            catch (Exception ex)
            {
                //Logger.Log
            }
            return products;
        }

        public static ProductModel GetProductById(int productId)
        {
            ProductModel product = GetProductsFromFile().Where(m => m.ProductID == productId).FirstOrDefault();
            return product;
        }

        public static Result SaveProductToFile(ProductModel product)
        {
            Result result = new Result();
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                products = GetProductsFromFile();

                product.ProductID = GetNewProductId(products);
                products.Add(product);

                ClearJsonFile(FilePath);
                result = SaveToFile(products);

                if (!result.IsSuccess)
                {
                    throw new Exception(result.Error);
                }
            }
            catch (Exception ex)
            {
                result = new Result(ex);
            }
            return result;
        }

        public static Result EditProduct(ProductModel model)
        {
            Result result = new Result();
            List<ProductModel> list = GetProductsFromFile();
            if (list.Any())
            {
                var item = list.Where(m => m.ProductID == model.ProductID).FirstOrDefault();
                if(item != null)
                {
                    int index = list.IndexOf(item);
                    list.RemoveAt(index);
                    list.Insert(index, model);

                    ClearJsonFile(FilePath);
                    result = SaveToFile(list);
                }
            }
            return result;

        }
        private static int GetNewProductId(List<ProductModel> products)
        {
            int id = 1;
            if (products.Any())
            {
                id = products.Max(m => m.ProductID) + 1;
            }
            return id;
        }
        public static Result DeleteProduct(int productId)
        {
            Result result = new Result();
            List<ProductModel> list = GetProductsFromFile();
            if (list.Any())
            {
                var product = list.Where(m => m.ProductID == productId).FirstOrDefault();
                if(product != null)
                {
                    if (list.Remove(product))
                    {
                        ClearJsonFile(FilePath);
                        result = SaveToFile(list);

                    }
                }
            }
            return result;
            
        }


    }
}