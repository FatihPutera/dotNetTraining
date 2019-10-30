﻿using LatihanASP.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatihanASP.Domain.Models.ProductDetails.Services
{
    public abstract class Service : ProductDetail
    {
        public ProductDetailCalculatorParameter parameter { get; set; }

        public Service(char Delimeter=';') : base(Delimeter)
        {
        }

        public string CostCalculationMethod { get; set; }

        public override void setAdditionalParameter(ProductDetailCalculatorParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}