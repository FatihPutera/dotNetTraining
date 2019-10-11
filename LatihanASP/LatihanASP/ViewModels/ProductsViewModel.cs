using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LatihanASP.EntityFramworks;

namespace LatihanASP.ViewModels
{
    public class ProductsViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public string ProductType { get; set; }

        public Dictionary<string, object> ProductDetail { get; set; }

        public ProductsViewModel()
        {

        }

        public ProductsViewModel(Product entity)
        {
            ProductID = entity.ProductID;
            ProductName = entity.ProductName;
            SupplierID = entity.SupplierID;
            CategoryID = entity.CategoryID;
            QuantityPerUnit = entity.QuantityPerUnit;
            UnitPrice = entity.UnitPrice;
            UnitsInStock = entity.UnitsInStock;
            ReorderLevel = entity.ReorderLevel;
            Discontinued = entity.Discontinued;

        }


    }


}
