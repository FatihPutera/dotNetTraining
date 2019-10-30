﻿using LatihanASP.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanASP.Domain.Models.ProductDetails
{
    interface IProductDetailCalculator
    {
        void setAdditionalParameter(ProductDetailCalculatorParameter parameter);
        decimal calculateProductCost();
    }
}