using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LatihanASP.EntityFramworks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LatihanASP.ViewModels;

namespace LatihanASP.ViewModels
{
    public class OrderCustomViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; } 

        public OrderCustomViewModel()
        {

        }

        public OrderCustomViewModel(Order_Detail entity)
        {
            ProductID = entity.Product.ProductID;
            ProductName = entity.Product.ProductName;
            CategoryName = entity.Product.Category.CategoryName;
            SupplierName = entity.Product.Supplier.CompanyName;
            UnitPrice = entity.UnitPrice;
            Quantity = entity.Quantity;
            Total = entity.Quantity * entity.UnitPrice-(entity.UnitPrice*(decimal)entity.Discount) ;
        }

    }
}