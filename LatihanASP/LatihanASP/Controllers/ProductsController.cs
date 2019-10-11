using LatihanASP.EntityFramworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LatihanASP.ViewModels;

namespace LatihanASP.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {

        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            var db = new DB_Context();
            try
            {
                var listProductsEntity = db.Products.ToList();

                List<ProductsViewModel> listProducts = new List<ProductsViewModel>();

                Dictionary<string, object> result = new Dictionary<string, object>();

                foreach (var item in listProductsEntity)
                {
                    ProductsViewModel products = new ProductsViewModel()
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        SupplierID = item.SupplierID,
                        CategoryID = item.CategoryID,
                        QuantityPerUnit = item.QuantityPerUnit,
                        UnitPrice = item.UnitPrice,
                        UnitsInStock = item.UnitsInStock,
                        ReorderLevel = item.ReorderLevel,
                        Discontinued = item.Discontinued

                    };
                    listProducts.Add(products);
                };

                result.Add("Message", "Read Data Succses");
                result.Add("Data", listProducts);

                db.Dispose();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ProductsViewModel dataBody)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();


                Product newProduct = new Product()
                {

                        ProductID = dataBody.ProductID,
                        ProductName = dataBody.ProductName,
                        SupplierID = dataBody.SupplierID,
                        CategoryID = dataBody.CategoryID,
                        QuantityPerUnit = dataBody.QuantityPerUnit,
                        UnitPrice = dataBody.UnitPrice,
                        UnitsInStock = dataBody.UnitsInStock,
                        ReorderLevel = dataBody.ReorderLevel,
                        Discontinued = dataBody.Discontinued


                };
                DB.Products.Add(newProduct);
                DB.SaveChanges();
                DB.Dispose();
                result.Add("Message", "Read Data Succses");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        ////////////////////////////////////////////////////////////////////////
        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] ProductsViewModel dataBody)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                Product product = DB.Products.Find(dataBody.ProductID);

                product.ProductID = dataBody.ProductID;
                product.ProductName = dataBody.ProductName;
                product.CategoryID = dataBody.CategoryID;
                product.QuantityPerUnit = dataBody.QuantityPerUnit;
                product.UnitPrice = dataBody.UnitPrice;
                product.UnitsInStock = dataBody.UnitsInStock;
                product.ReorderLevel = dataBody.ReorderLevel;
                product.Discontinued = dataBody.Discontinued;

                DB.SaveChanges();
                DB.Dispose();
                result.Add("Message", "Update Data Succses");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /////////////////////////////
        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int ProductID)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                Product product = DB.Products.Where(data => data.ProductID == ProductID).FirstOrDefault();
                DB.Products.Remove(product);
                DB.SaveChanges();
                DB.Dispose();
                result.Add("Message", "Delete Data Succses");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /////////////////////////////////
        [Route("Soal")]
        [HttpGet]
        public IHttpActionResult Soal()
        {
            var DB = new DB_Context();
            try
            {
                
                Dictionary<string, object> result = new Dictionary<string, object>();

                IEnumerable<ProductsViewModel> expensiveValue = DB.Products.Where(data => data.UnitPrice == DB.Products.Max(max=> max.UnitPrice))
                    .ToList().Select(item=> new ProductsViewModel(item));
                IEnumerable<ProductsViewModel> cheapestValue = DB.Products.Where(data => data.UnitPrice == DB.Products.Min(min => min.UnitPrice))
                    .ToList().Select(item => new ProductsViewModel(item));
                IEnumerable<ProductsViewModel> avgValue = DB.Products.Where(data => data.UnitPrice < DB.Products.Average(avg => avg.UnitPrice))
                    .ToList().Select(item => new ProductsViewModel(item));

                DB.Dispose();
                result.Add("expensiveValue", expensiveValue);
                result.Add("cheapestValue", cheapestValue);
                result.Add("minAverageValue", avgValue);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /////////////////////
        /////////////////////////////////
        [Route("Filter")]
        [HttpGet]
        public IHttpActionResult Filter(string productName=null, string categoryName=null, decimal? byPrice = null)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                var temp = DB.Products.AsQueryable();
                if (productName != null)
                {
                    temp = temp.Where(data => data.ProductName.ToLower().Contains(productName.ToLower()));
                }
                if (categoryName != null)
                {
                    temp = temp.Where(data => data.Category.CategoryName.ToLower().Contains(categoryName.ToLower()));
                }
                if (byPrice!=null)
                {
                    temp = temp.Where(data => data.UnitPrice <= byPrice);
                }


                var listProduct = temp.ToList().Select(item => new ProductsViewModel(item));

                result.Add("data",listProduct);
                DB.Dispose();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        ///////////////////////////

    }
}