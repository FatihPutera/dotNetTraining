using LatihanASP.EntityFramworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LatihanASP.ViewModels;

namespace LatihanASP.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {

        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            var db = new DB_Context();
            try
            {
                var listCategoryEntity = db.Categories.ToList();

                List<CategoryViewModel> listProduct = new List<CategoryViewModel>();

                Dictionary<string, object> result = new Dictionary<string, object>();

                foreach (var item in listCategoryEntity)
                {
                    CategoryViewModel category = new CategoryViewModel()
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        Description = item.Description,
                        Picture = item.Picture
                    };
                    listProduct.Add(category);
                };

                result.Add("Message", "Read Data Succses");
                result.Add("Data", listProduct);

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
        public IHttpActionResult Create([FromBody] CategoryViewModel dataBody)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();


                Category newCategory = new Category()
                {

                    CategoryID = dataBody.CategoryID,
                    CategoryName = dataBody.CategoryName,
                    Description = dataBody.Description,
                    Picture = dataBody.Picture

                };
                DB.Categories.Add(newCategory);
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
        public IHttpActionResult Update([FromBody] CategoryViewModel dataBody)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                Category category = DB.Categories.Find(dataBody.CategoryID);

                category.CategoryID = dataBody.CategoryID;
                category.CategoryName = dataBody.CategoryName;
                category.Description = dataBody.Description;
                category.Picture = dataBody.Picture;

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
        public IHttpActionResult Delete(int categoryID)
        {
            var DB = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                Category category = DB.Categories.Where(data => data.CategoryID == categoryID).FirstOrDefault();
                DB.Categories.Remove(category);
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
    }



    
        
}