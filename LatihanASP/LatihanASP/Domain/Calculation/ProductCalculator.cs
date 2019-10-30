﻿using LatihanASP.Domain.Models.ProductDetails;
using LatihanASP.Domain.Models.ProductDetails.Items.Details;
using LatihanASP.Domain.Models.ProductDetails.Services.Details;
using LatihanASP.Domain.ViewModels;
using LatihanASP.EntityFramworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatihanASP.Domain.Calculation
{
    public class ProductCalculator
    {
        private char Delimeter;

        public ProductCalculator(char Delimeter) {
            this.Delimeter = Delimeter;
        }

        public void calculateProductUnitPrice(Product product, ProductDetailCalculatorParameter parameter) {

            ProductDetail productDetail = null;

            if(product.ProductType != null)
            {
                if (product.ProductType.Equals("FoodAndBeverageItems"))
                {
                    productDetail = new FoodAndBeverage(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("MaterialItems"))
                {
                    productDetail = new Material(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("GarmentItems"))
                {
                    productDetail = new Garment(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("TransportationServices"))
                {
                    productDetail = new Transportation(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("TelecommunicationServices"))
                {
                    productDetail = new Telecommunication(this.Delimeter, product);
                }
                else
                {
                    throw new Exception("Unknown Product Type");
                }
                
                productDetail.setAdditionalParameter(parameter);
                product.UnitPrice = productDetail.calculateProductCost() * productDetail.getDecCostRate();
            }
        }
    }
}