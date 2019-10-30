using System.Collections.Generic;
using LatihanASP.EntityFramworks;

namespace LatihanASP.Domain.Models.ProductDetails.Items.Details
{
    public class FoodAndBeverage : Item
    {
        public string ExpiredDate { get; set; }
        public string NetWeight { get; set; }
        public string Ingredients { get; set; }
        public string DailyValue { get; set; }
        public string Certification { get; set; }

        public FoodAndBeverage(char Delimeter, Product product) : base(Delimeter)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(this.Delimeter);
                this.ProductDescription = prod[0];
                this.ProductionCode = prod[1];
                this.ProductionDate = prod[2];
                this.ExpiredDate = prod[3];
                this.NetWeight = prod[4];
                this.Ingredients = prod[5];
                this.DailyValue = prod[6];
                this.Certification = prod[7];
                this.UnitOfMeasurement = prod[8];
                this.CostRate = prod[9];
            }
        }

        public FoodAndBeverage(char Delimeter, Dictionary<string, object> dictionary) : base(Delimeter)
        {
            this.Certification = dictionary["Certification"].ToString();
            this.ExpiredDate = dictionary["ExpiredDate"].ToString();
            this.NetWeight = dictionary["NetWeight"].ToString();
            this.Ingredients = dictionary["Ingredients"].ToString();
            this.DailyValue = dictionary["DailyValue"].ToString();
            this.UnitOfMeasurement = dictionary["UnitOfMeasurement"].ToString();
            this.CostRate = dictionary["CostRate"].ToString();
            this.ProductionCode = dictionary["ProductionCode"].ToString();
            this.ProductionDate = dictionary["ProductionDate"].ToString();
            this.ProductDescription = dictionary["ProductDescription"].ToString();
        }

        public override Dictionary<string, object> ConvertToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("ProductID", this.ProductID);
            result.Add("ProductDescription", this.ProductDescription);
            result.Add("ProductionCode", this.ProductionCode);
            result.Add("ProductionDate", this.ProductionDate);
            result.Add("ExpiredDate", this.ExpiredDate);
            result.Add("NetWeight", this.NetWeight);
            result.Add("Ingredients", this.Ingredients);
            result.Add("DailyValue", this.DailyValue);
            result.Add("Certification", this.Certification);
            result.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            result.Add("CostRate", this.CostRate);

            return result;
        }

        public override string ConvertToString()
        {
            return this.appendWithDelimiter(
                this.ProductDescription, this.ProductionCode, this.ProductionDate, this.ExpiredDate, this.NetWeight,
                this.Ingredients, this.DailyValue, this.Certification, this.UnitOfMeasurement, this.CostRate);
        }

    }
}