using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using LatihanASP.ViewModels.ProductCustom.Items;

namespace LatihanASP.ViewModels.ProductCustom.Items
{
    interface IProductItem
    {
        string UnitOfMeasurement { get; set; }
        string CostRate { get; set; }
        Dictionary<string, object> fromItemToDict();
        string ConvertToItem();

        decimal unitPriceItemCalculation();
    }

}