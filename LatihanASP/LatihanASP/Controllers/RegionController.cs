using LatihanASP.EntityFramworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LatihanASP.ViewModels;

namespace LatihanASP.Controllers
{
    [RoutePrefix("api/Region")]
    public class RegionController : ApiController
    {
        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll(int? regionID = null)
        {
            using (var DB = new DB_Context())
            {
                try
                {
                    var tem = DB.Regions.AsQueryable();
                    RegionDetailViewModel regionObj = new RegionDetailViewModel();
                    List<RegionDetailViewModel> listRegion = new List<RegionDetailViewModel>();
                    if (regionID != null)
                    {
                        tem = tem.Where(data => data.RegionID == regionID);
                    }
                    var listRegionEntity = tem.AsEnumerable().ToList();
                    foreach (var item in listRegionEntity)
                    {
                        RegionDetailViewModel region = new RegionDetailViewModel(item);
                        listRegion.Add(region);
                    }
                    return Ok(regionObj.finalResult(listRegion, "Read Data Success"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //////////////////////////////////////////////////////////
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] RegionDetailViewModel dataBody)
        {
            using (var DB = new DB_Context())
            {
                try
                {
                    List<RegionDetailViewModel> listRegion = new List<RegionDetailViewModel>();
                    var temp = dataBody.convertToRegion();
                    DB.Regions.Add(temp);
                    DB.SaveChanges();
                    var reg = DB.Regions.Where(dt => dt.RegionID == dataBody.RegionID).AsEnumerable().ToList();
                    RegionDetailViewModel regionView = new RegionDetailViewModel(reg);
                    listRegion.Add(regionView);
                    dataBody.Insertdata(DB);
                    return Ok(dataBody.finalResult(listRegion, "Insert Data Success"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //////////////////////////////////////////////////////////
        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] RegionDetailViewModel dataBody)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    List<RegionDetailViewModel> listRegion = new List<RegionDetailViewModel>();
                    Region region = db.Regions.Find(dataBody.RegionID);
                    var temp = dataBody.convertToRegion2(region);
                    RegionDetailViewModel reg = new RegionDetailViewModel(temp);
                    listRegion.Add(reg);
                    db.SaveChanges();
                    return Ok(dataBody.finalResult(listRegion, "Update Data Success"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////

        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int regionID)
        {
            using (var DB = new DB_Context())
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var territory = DB.Territories.Where(data => data.RegionID == regionID).ToList();
                    foreach (var item in territory)
                    {
                        DB.Territories.Remove(item);
                    }
                    Region region = DB.Regions.Where(data => data.RegionID == regionID).FirstOrDefault();
                    DB.Regions.Remove(region);
                    DB.SaveChanges();
                    result.Add("Message", "Delete data success");
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
        }
    }
}