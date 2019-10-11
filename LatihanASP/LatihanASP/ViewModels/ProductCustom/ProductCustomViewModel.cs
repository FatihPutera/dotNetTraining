using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LatihanASP.EntityFramworks;
using AutoMapper;

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
                        ProductDetail = food.fromFoodToDict();
                        break;
                    case "GarmentItems":
                        GarmentItemsViewModel garment = new GarmentItemsViewModel(product);
                        ProductDetail = garment.fromGarmentToDict();
                        break;
                    case "MaterialItems":
                        MaterialItemsViewModel materi = new MaterialItemsViewModel(product);
                        ProductDetail = materi.fromMaterialToDict();
                        break;
                    case "TransportationServices":
                        TransportationServicesViewModel trans = new TransportationServicesViewModel(product);
                        ProductDetail = trans.fromTransportationToDict();
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

        public Product convertToProduct()
        {
            var description = "";
            var config = new MapperConfiguration(cfg => { });
            var mapper = new Mapper(config);

            if (this.ProductType.Contains("FoodAndBeverageItems"))
            {
                FoodsAndBeverageItemsViewModel foods = mapper.Map<FoodsAndBeverageItemsViewModel>(this.ProductDetail);
                description = foods.convertToString();
            }
            else if (this.ProductType.Contains("MaterialItems"))
            {
                MaterialItemsViewModel materials = mapper.Map<MaterialItemsViewModel>(this.ProductDetail);
                description = materials.convertToString();
            }
            else if (this.ProductType.Contains("GarmentItems"))
            {
                GarmentItemsViewModel garments = mapper.Map<GarmentItemsViewModel>(this.ProductDetail);
                description = garments.convertToString();
            }
            else if (this.ProductType.Contains("TransportationServices"))
            {
                TransportationServicesViewModel transportations = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                description = transportations.convertToString();
            }

            return new Product()
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                SupplierID = this.SupplierID,
                CategoryID = this.CategoryID,
                QuantityPerUnit = this.QuantityPerUnit,
                UnitPrice = this.UnitPrice,
                UnitsInStock = this.UnitsInStock,
                UnitsOnOrder = this.UnitsOnOrder,
                ReorderLevel = this.ReorderLevel,
                Discontinued = this.Discontinued,
                ProductType = this.ProductType,
                ProductDetail = description,
            };
        }

        public Dictionary<string, object> FinalResult(List<ProductCustomViewModel> listObject = null, string msg = "")
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Message", msg);
            result.Add("Data", listObject);
            return (result);
        }
    }
}