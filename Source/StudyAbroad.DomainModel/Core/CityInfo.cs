using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Framework;

namespace StudyAbroad.DomainModel.Core
{
    public class CityInfo : DomainBase<CityInfo>
    {
        #region Freebase
        //From Freebase
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string FullDescriptionURL { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string ImageURL { get; set; }
        /// <summary>
        /// Long only
        /// </summary>
        public virtual string Area { get; set; }
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual string Latitude { get; set; }
        /// <summary>
        /// Short and long
        /// </summary>
        public virtual string Longitude { get; set; }

        /// <summary>
        /// Long only
        /// </summary>
        //public virtual string Population { get; set; } // You can get density dividing population with area... if you still need it
        /// <summary>
        /// Long only
        /// Key: year, Value: number
        /// </summary>
        public virtual SortedList <string, int> Population { get; set; }
               
        /// <summary>
        /// Long only
        /// </summary>
        public virtual List<ClimateData> Climate { get; set; }

        /// <summary>
        /// Long only
        /// </summary>
        public virtual List<TouristAttraction> TouristAttractions { get; set; }

        #endregion

        #region Numbeo

        public List<ItemPrice> CostOfLife { get; set; }

        #endregion
    }

    public class ClimateData
    {
        public string Month { get; set; }
    
        public decimal AvgMinTemp { get; set; }
        public decimal AvgMaxTemp { get; set; }
        public decimal AvgRainfall { get; set; }

        public ClimateData(string inMonth, decimal inAvgMinTemp, decimal inAvgMaxTemp, decimal inAvgRainfall)
        {
            Month = inMonth;
            AvgMaxTemp = inAvgMaxTemp;
            AvgMinTemp = inAvgMinTemp;
            AvgRainfall = inAvgRainfall;
        }
    }

    public class TouristAttraction
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public TouristAttraction(string inName, string inWebsite, decimal inLongitude, decimal inLatitude)
        {
            Name = inName;
            Website = inWebsite;
            Longitude = inLongitude;
            Latitude = inLatitude;
        }
    }

    public class ItemPrice
    {
        public string ItemName { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }

        public ItemPrice(string inItemName, decimal inAvgPrice, decimal inMinPrice, decimal inMaxPrice)
        {
            ItemName = inItemName;
            AvgPrice = inAvgPrice;
            MinPrice = inMinPrice;
            MaxPrice = inMaxPrice;
        }
    }
}
