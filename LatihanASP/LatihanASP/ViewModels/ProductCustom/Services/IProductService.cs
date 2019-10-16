using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace LatihanASP.ViewModels.ProductCustom.Services
{
        interface IProductService
        {
            Dictionary<string, object> fromServiceToDict();
            string ConvertToService();

            decimal? rateCostCalculation(string condition = null, int? userDemand = null, decimal? Duration = null);
        }
}