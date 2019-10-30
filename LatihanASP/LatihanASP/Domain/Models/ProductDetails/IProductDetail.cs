using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanASP.Domain.Models.ProductDetails
{
    interface IProductDetail
    {
        string ConvertToString();
        Dictionary<string, object> ConvertToDictionary();
    }
}
