using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using LatihanASP.EntityFramworks;
using LatihanASP.ViewModels;
using LatihanASP.ViewModels.ProductCustom;

namespace LatihanASP.Controllers
{
    [RoutePrefix("api/ProductDetail")]
    public class CustomProductController : ApiController
    {
        [Route("Read")]
        [HttpGet]
        public IHttpActionResult Read(int? productID = null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    var tem = db.Products.AsQueryable();
                    ProductCustomViewModel productObj = new ProductCustomViewModel();
                    List<ProductCustomViewModel> listProduct = new List<ProductCustomViewModel>();
                    if (productID != null)
                    {
                        tem = tem.Where(data => data.ProductID == productID);
                    }
                    foreach (var item in tem)
                    {
                        ProductCustomViewModel product = new ProductCustomViewModel(item);
                        listProduct.Add(product);
                    }
                    return Ok(productObj.FinalResult(listProduct, "Read Data Success"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ProductCustomViewModel dataBody, string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    Product product = new Product();
                    if (condition == null && userDemand == null && Duration != null)
                    {
                        product = dataBody.convertToProduct(null, null, Duration);
                    }
                    else if (condition != null && userDemand != null && Duration == null)
                    {
                        product = dataBody.convertToProduct(condition, userDemand, null);
                    }
                    else if (condition == null && userDemand == null && Duration == null)
                    {
                        product = dataBody.convertToProduct(condition, userDemand, null);
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Ok("Data Saved Successfully");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int ProID)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    ProductCustomViewModel obj = new ProductCustomViewModel();
                    Product product = db.Products.Where(data => data.ProductID == ProID).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return Ok(obj.FinalResult(null, "Delete data Success"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("calculateProductUnitPrice ")]
        [HttpPost]
        public IHttpActionResult calculateProductUnitPrice([FromBody] ProductCustomViewModel dataBody)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    var temp = db.Products.AsQueryable();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Product product = dataBody.convertToProduct();
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Ok("Data Saved Successfully");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getCost")]
        [HttpGet]
        public IHttpActionResult CostCalculation(string condition, int userdemand)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    var tem = db.Products.AsQueryable();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<CostCalculationViewModel> listProduct = new List<CostCalculationViewModel>();
                    tem = tem.Where(data => data.ProductType.Contains("TransportationServices"));
                    var listCostEntity = tem.AsEnumerable().ToList();
                    foreach (var item in listCostEntity)
                    {
                        CostCalculationViewModel product = new CostCalculationViewModel(item, condition, userdemand);
                        listProduct.Add(product);
                    }
                    result.Add("Message", "Read Data Success");
                    result.Add("Data", listProduct);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}