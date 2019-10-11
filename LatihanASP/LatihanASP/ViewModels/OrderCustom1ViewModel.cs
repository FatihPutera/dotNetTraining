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
    public class OrderCustom1ViewModel
    {
        public int? OrderID { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        public List<OrderCustomViewModel> ProductList { get; set; }

        public decimal GrandTotal { get; set; }

        public OrderCustom1ViewModel()
        {

        }

        public OrderCustom1ViewModel (int? orderId, string contactName, List<OrderCustomViewModel> orderList)
        {
            OrderID = orderId;
            ContactName = contactName;
            ProductList = orderList;
            GrandTotal = orderList.Sum(data => data.Total);
        }
    }
} 