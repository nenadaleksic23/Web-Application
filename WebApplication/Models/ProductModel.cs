using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Models
{
    public class ProductModel
    {
        public ProductModel(){}
        public ProductModel(Product p)
        {
            if(p != null)
            {
                this.ProductID = p.ProductID;
                ProductName = p.ProductName;
                ProductDescription = p.ProductDescription;
                Category = p.Category;
                Manufacturer = p.Manufacturer;
                Supplier = p.Supplier;
                Price = p.Price;
            }
        }
        public int ProductID { get; set; }
        [Required(ErrorMessage ="You must enter Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "You must enter description")]
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        [Required(ErrorMessage = "You must enter price")]
        public decimal Price { get; set; }
    }
}