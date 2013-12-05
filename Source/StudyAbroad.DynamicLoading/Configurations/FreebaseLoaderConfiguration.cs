using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DynamicLoading.Configurations
{
    public class FreebaseLoaderConfiguration : LoaderConfiguration
    {
        public FreebaseLoaderConfiguration(University inUniversity)
        {
            try
            {
                SetSearchParameters(inUniversity.Name, "/education/university");
                Setup(inUniversity, InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid);
            }
            catch (Exception)
            {
                SetSearchParameters(inUniversity.Info.EnglishName, "/education/university");
                Setup(inUniversity, InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid);
            }

        }

        public FreebaseLoaderConfiguration(City inCity)
        {
            try
            {
                SetSearchParameters(inCity.Name + ", " + inCity.ContainedBy.Name, "/location/citytown");
                Setup(inCity, InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid);
            }
            catch (Exception)
            {
                try
                {
                    SetSearchParameters(inCity.Name, "/location/citytown");
                    Setup(inCity, InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid);
                }
                catch (Exception)
                {
                    try
                    {
                        var cityName = inCity.Name.Split(' ')[0];
                        SetSearchParameters(cityName, "/location/citytown");
                        Setup(inCity, InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid);
                    }
                    catch (Exception)
                    {
                        var cityName = inCity.Name.Split('-')[0];
                        SetSearchParameters(cityName, "/location/citytown");
                        Setup(inCity, InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid);
                    }
                    
                }
                
            }
            
        }

        public override void Setup(DataEntity inEntity, InfoDomainEnum inDomain, InfoCategoryEnum inCategory)
        {
            var link = inEntity.Links.FirstOrDefault(u => u.InfoDomain == inDomain && u.InfoCategory == inCategory);
            if (link == null)
            {
                var mid = ApiUtilities.FreebaseClient.GetMid(GetParameter("QueryText"), GetParameter("Type"));
                //var mid = FreebaseUtilities.Utils.GetMid(GetParameter("QueryText"), GetParameter("Type"));
                inEntity.RegisterDataSource(InfoDomainEnum.Freebase, InfoCategoryEnum.FreebaseMid, mid);
                SetMid(mid);
            }
            else
                SetMid(link.ToString());              
        }
    }
}
