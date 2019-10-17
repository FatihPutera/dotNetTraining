using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LatihanASP.EntityFramworks;
using AutoMapper;
using LatihanASP.ViewModels.ProductCustom.Items;
using LatihanASP.ViewModels.ProductCustom.Services;

namespace LatihanASP.ViewModels.ProductCustom
{
    public class ProductCustomViewModel : ProductsViewModel
    {
        public ProductCustomViewModel()
        {
        }
        public ProductCustomViewModel(Product product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            SupplierID = product.SupplierID;
            CategoryID = product.CategoryID;
            QuantityPerUnit = product.QuantityPerUnit;
            UnitPrice = product.UnitPrice;
            UnitsInStock = product.UnitsInStock;
            UnitsOnOrder = product.UnitsOnOrder;
            ReorderLevel = product.ReorderLevel;
            Discontinued = product.Discontinued;
            ProductType = product.ProductType;
            if (ProductType != null)
            {
                switch (ProductType)
                {
                    case "FoodAndBeverageItems":
                        FoodsAndBeverageItemsViewModel food = new FoodsAndBeverageItemsViewModel(product);
                        ProductDetail = food.fromItemToDict();
                        break;
                    case "GarmentItems":
                        GarmentItemsViewModel garment = new GarmentItemsViewModel(product);
                        ProductDetail = garment.fromItemToDict();
                        break;
                    case "MaterialItems":
                        MaterialItemsViewModel materi = new MaterialItemsViewModel(product);
                        ProductDetail = materi.fromItemToDict();
                        break;
                    case "TransportationServices":
                        TransportationServicesViewModel trans = new TransportationServicesViewModel(product);
                        ProductDetail = trans.fromServiceToDict();
                        break;
                    case "TelecommunicationServices":
                        TelecomunicationServiceViewModel telecomunication = new TelecomunicationServiceViewModel(product);
                        ProductDetail = telecomunication.fromServiceToDict();
                        break;
                    default:
                        ProductDetail = null;
                        break;
                }
            }
            else
            {
                ProductDetail = null;
            }
        }
        public Product convertToProduct(string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            decimal? price = null;
            var prodDet = "";
            var config = new MapperConfiguration(cfg => { });
            var mapper = new Mapper(config);
            if (this.ProductType.Equals("FoodAndBeverageItems"))
            {
                FoodsAndBeverageItemsViewModel food = mapper.Map<FoodsAndBeverageItemsViewModel>(this.ProductDetail);
                prodDet = food.ConvertToItem();
                price = food.unitPriceItemCalculation();
            }
            else if (this.ProductType.Equals("MaterialItems"))
            {
                MaterialItemsViewModel materi = mapper.Map<MaterialItemsViewModel>(this.ProductDetail);
                prodDet = materi.ConvertToItem();
                price = materi.unitPriceItemCalculation();
            }
            else if (this.ProductType.Equals("GarmentItems"))
            {
                GarmentItemsViewModel garment = mapper.Map<GarmentItemsViewModel>(this.ProductDetail);
                prodDet = garment.ConvertToItem();
                price = garment.unitPriceItemCalculation();
            }
            else if (this.ProductType.Equals("TransportationServices"))
            {
                TransportationServicesViewModel trans = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                prodDet = trans.ConvertToService();
                price = trans.rateCostCalculation(condition, userDemand, Duration);
            }
            else if (this.ProductType.Equals("TelecommunicationServices"))
            {
                TelecomunicationServiceViewModel tele = mapper.Map<TelecomunicationServiceViewModel>(this.ProductDetail);
                prodDet = tele.ConvertToService();
                price = tele.rateCostCalculation(condition, userDemand, Duration);
            }
            else
            {
                price = 0;
                ProductDetail = null;
            }
            return new Product()
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                SupplierID = this.SupplierID,
                CategoryID = this.CategoryID,
                QuantityPerUnit = this.QuantityPerUnit,
                UnitPrice = price,
                UnitsInStock = this.UnitsInStock,
                UnitsOnOrder = this.UnitsOnOrder,
                ReorderLevel = this.ReorderLevel,
                Discontinued = this.Discontinued,
                ProductType = this.ProductType,
                ProductDetail = prodDet
            };
        }

        public Dictionary<string, object> FinalResult(List<ProductCustomViewModel> listObject, string msg)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Message", msg);
            result.Add("Data", listObject);
            return (result);
        }
    }
}