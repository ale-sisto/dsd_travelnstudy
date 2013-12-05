using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.CostOfLife
{
    public static class CostOfLife
    {
        private static ItemIndexCollection _indices;
        private static List<ItemIndex> _readedIndices;
        private static decimal _baseFactor = (decimal)4028.229;

        // Local_Puchasing_Power_Index = Affordability(This_City) / Affordability(New York)
        //Affordability (of a city) = Average_monthly_disposable_income / sum_of (Price_in_the_city * (1.5 * cpi_factor) + rent_factor)
        public static CostCategoriesEnum GetCostIndex(City inCity)
        {
            if (inCity == null)
                throw new Exception("City is not sent.");

            if (_indices == null)
                DeserializeCostIndices();

            _readedIndices = new List<ItemIndex>();

            if (inCity.Info.CostOfLife == null)
                Factories.BLLFactory.Location().City().GetCostOfLife(inCity);
            decimal cityFactor = GetCostFactor(inCity, true);

            if (_baseFactor == 0)
            {
                City baseCity = Factories.BLLFactory.Location().GetByName("Berlin") as City;
                if (baseCity.Info.CostOfLife == null)
                    Factories.BLLFactory.Location().City().GetCostOfLife(baseCity);
                _baseFactor = GetCostFactor(baseCity, false);
            }

            int index = (int) ((cityFactor/_baseFactor)*100);

            return DetermineCategory(index);
        }

        private static CostCategoriesEnum DetermineCategory(int index)
        {
                        if (index == 0)
                return CostCategoriesEnum.Unknown;
            if (index < 50)
                return CostCategoriesEnum.VeryCheap;
            if (index < 80)
                return CostCategoriesEnum.Cheap;
            if (index < 110)
                return CostCategoriesEnum.Moderate;
            if (index < 140)
                return CostCategoriesEnum.Expensive;
            if (index >= 140)
                return CostCategoriesEnum.VeryExpensive;
            else
                return CostCategoriesEnum.Unknown;
        }

        private static decimal GetCostFactor(City inCity, bool allIndices)
        {
            if (inCity.Info.CostOfLife == null)
                return 0;

            List<ItemIndex> indeices = allIndices ? _indices.Indices.ToList() : _readedIndices;
            decimal sum = 0;
            foreach (ItemIndex index in indeices)
            {
                ItemPrice itemPrice =
                    inCity.Info.CostOfLife.FirstOrDefault(x => x.ItemName.Trim().ToLower().Contains(index.Name.Trim().ToLower())/* == index.Name + ", " + index.Category*/);
                if (itemPrice != null)
                {
                    sum += itemPrice.AvgPrice*(((decimal) 1.5*index.CpiFactor) + index.RentFactor);
                    if (allIndices)
                        _readedIndices.Add(index);
                }
            }
            return sum;
        }
        private static void DeserializeCostIndices()
        {
            //const string path = @"..\..\..\CostIndices.xml";
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof (ItemIndexCollection));

            byte[] byteArray = Encoding.ASCII.GetBytes(Resources.Files.CostIndices);
            MemoryStream stream = new MemoryStream( byteArray );
            //System.IO.StreamReader reader = new System.IO.StreamReader(path);
            _indices = (ItemIndexCollection) serializer.Deserialize(stream);
            stream.Close();
        }
    }

    [Serializable()]
    public class ItemIndex
    {
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("Category")]
        public string Category { get; set; }

        [System.Xml.Serialization.XmlElement("CpiFactor_")]
        public string CpiFactorStr { get; set; }

        [System.Xml.Serialization.XmlElement("RentFactor_")]
        public string RentFactorStr { get; set; }

        public decimal CpiFactor
        {
            get { return StringToDouble(CpiFactorStr); }
        }

        public decimal RentFactor
        {
            get { return StringToDouble(RentFactorStr); }
        }

        private decimal StringToDouble(string value)
        {
            decimal result;
            Decimal.TryParse(value, out result);
            return result;
        }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("Collection")]
    public class ItemIndexCollection
    {
        [System.Xml.Serialization.XmlArray("root")]
        [System.Xml.Serialization.XmlArrayItem("row", typeof (ItemIndex))]
        public ItemIndex[] Indices { get; set; }
    }
}
