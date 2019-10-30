using System.Collections.Generic;
using LatihanASP.EntityFramworks;

namespace LatihanASP.Domain.Models.ProductDetails.Items.Details
{
    public class Garment : Item
    {
        public string GarmentsType { get; set; }
        public string Fabrics { get; set; }
        public string GenderRelated { get; set; }
        public string IsWaterProof { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string AgeGroup { get; set; }

        public Garment(char Delimeter, Product product) : base(Delimeter)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(this.Delimeter);
                this.ProductDescription = prod[0];
                this.ProductionCode = prod[1];
                this.ProductionDate = prod[2];
                this.GarmentsType = prod[3];
                this.Fabrics = prod[4];
                this.GenderRelated = prod[5];
                this.IsWaterProof = prod[6];
                this.Color = prod[7];
                this.Size = prod[8];
                this.AgeGroup = prod[9];
                this.UnitOfMeasurement = prod[10];
                this.CostRate = prod[11];
            }
        }

        public override Dictionary<string, object> ConvertToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("ProductID", this.ProductID);
            result.Add("ProductDescription", this.ProductDescription);
            result.Add("ProductionCode", this.ProductionCode);
            result.Add("ProductionDate", this.ProductionDate);
            result.Add("GarmentsType", this.GarmentsType);
            result.Add("Fabrics", this.Fabrics);
            result.Add("GenderRelated", this.GenderRelated);
            result.Add("IsWaterProof", this.IsWaterProof);
            result.Add("Color", this.Color);
            result.Add("Size", this.Size);
            result.Add("AgeGroup", this.AgeGroup);
            result.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            result.Add("CostRate", this.CostRate);

            return result;
        }

        public override string ConvertToString()
        {
            return this.appendWithDelimiter(
                this.ProductDescription, this.ProductionCode, this.ProductionDate, this.GarmentsType, this.Fabrics,
                this.GenderRelated, this.IsWaterProof, this.Color, this.Size, this.AgeGroup, this.UnitOfMeasurement, this.CostRate);
        }
    }
}