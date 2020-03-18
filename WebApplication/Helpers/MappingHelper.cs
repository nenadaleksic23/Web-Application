using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Helpers
{
    public static class MappingHelper
    {
        public static Product ProductModelToProductMapExtension(this Product product, ProductModel productModel)
        {
            product.ProductName = productModel.ProductName;
            product.Category = productModel.Category;
            product.Manufacturer = productModel.Manufacturer;
            product.Price = productModel.Price;
            product.ProductDescription = productModel.ProductDescription;
            product.Supplier = productModel.Supplier;

            return product;
        }
    }
}