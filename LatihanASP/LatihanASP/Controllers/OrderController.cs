using LatihanASP.EntityFramworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LatihanASP.ViewModels;

namespace LatihanASP.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        [Route("read")]
        [HttpGet]
        public IHttpActionResult Read(int? orderId=null)
        {
            try
            {
                using (var DB = new DB_Context())
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<OrderCustom1ViewModel> listDetailData = new List<OrderCustom1ViewModel>(); 
                    var dataOrders = DB.Orders.AsQueryable();
                    if (orderId != null)
                    {
                        dataOrders = dataOrders.Where(item => item.OrderID == orderId);

                    }

                    var listOrder = dataOrders.AsEnumerable().ToList();

                    foreach (var item in listOrder)
                    {
                        var listProductDetail = item.Order_Details.ToList().Select(data => new OrderCustomViewModel(data)).ToList();
                        OrderCustom1ViewModel orderDetail = new OrderCustom1ViewModel(item.OrderID, item.Customer.ContactName, listProductDetail);
                        listDetailData.Add(orderDetail);
                    }
                    result.Add("data",listDetailData);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


     }
}