using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Framework;
using StudyAbroad.DynamicLoading.ApiUtilities;
using RestSharp;

namespace StudyAbroad.DynamicLoading.Core
{
    public class NumbeoLoader : Loader<City>
    {

        public NumbeoLoader(LoaderConfiguration inConfiguration)
            : base(inConfiguration)
        {
        }

        public override void Load(List<City> items)
        {
            throw new Exception("No loading of cities is implemented from the Numbeo data source.");
        }

        public override void Update(City obj, ParameterCollection parameters)
        {
            string city;
            string country;
            if (obj.ContainedBy is State) 
            {
                var code = obj.ContainedBy.Code.Split('-')[1];
                city = obj.Name + ", " + code;
                country = "United States";
            }
            else
            {
                city = obj.Name;
                country = obj.ContainedBy.Name;
            }
            ApiResponse response = NumbeoClient.Read(city, country);
            ParseResult(response.ObjectResult, obj);
            if (obj.Info.CostOfLife.Count == 0)
            {
                response = NumbeoClient.Read(city);
                ParseResult(response.ObjectResult, obj);
            }
        }

        private void ParseResult(dynamic objRes, City obj)
        {
            obj.Info.CostOfLife = new List<ItemPrice>();
            try
            {
                foreach (dynamic price in objRes.prices)
                {
                    try
                    {
                        string itemName = price.item_name;
                        decimal avg = price.average_price;
                        decimal min = 0;
                        try { min = price.lowest_price; }
                        catch { }
                        decimal max = 0;
                        try { max = price.highest_price; }
                        catch { }


                        obj.Info.CostOfLife.Add(new ItemPrice(itemName, avg, min, max));
                    }
                    catch
                    {
                        try
                        {
                            string itemName = objRes.prices.item_name;
                            decimal avg = objRes.prices.average_price;
                            decimal min = 0;
                            try { min = objRes.prices.lowest_price; }
                            catch { }
                            decimal max = 0;
                            try { max = objRes.prices.highest_price; }
                            catch { }


                            obj.Info.CostOfLife.Add(new ItemPrice(itemName, avg, min, max));
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
