using LatihanASP.Domain.Models.ProductDetails;
using LatihanASP.Domain.Models.ProductDetails.Items.Details;
using LatihanASP.Domain.Models.ProductDetails.Services.Details;
using LatihanASP.Domain.ViewModels;
using LatihanASP.EntityFramworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatihanASP.Domain.Validator
{
    public class ProductValidator
    {
        public bool isValidProductdetail(ProductDetail productDetail, string productType){


            if (productDetail.GetType()==typeof()) {
                return true;
            }
            else if (productDetail.GetType() == typeof())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool isValidProductdetail(Dictionary<string,object> productDetail, string productType)
        {

            if (productDetail == typeof())
            {
                return true;
            }
            else if (productDetail == typeof())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isValidProductdetail(string productDetail, string productType)
        {

            return true;
        }
    }
}