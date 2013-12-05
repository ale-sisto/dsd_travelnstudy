using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DynamicLoading.Framework;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.DynamicLoading.Configurations
{
    /// <summary>
    /// Loading configuration for loading top universities in the world or by continent
    /// </summary>
    public class IcuOrgLoaderConfiguration : LoaderConfiguration
    {
        public IcuOrgLoaderConfiguration(Location inLocation)
        {
            Setup(inLocation, InfoDomainEnum.IcuOrg, InfoCategoryEnum.TopUniversities);
            if (inLocation is Country)
                SetParameter("CountryName", inLocation.Name);
            else if (inLocation is State)
                SetParameter("CountryName", inLocation.Name);
        }

        public IcuOrgLoaderConfiguration(University inUniversity)
        {
            Setup(inUniversity, InfoDomainEnum.IcuOrg, InfoCategoryEnum.UniversityInfo);
        }

        public override void Setup(DataEntity inEntity, InfoDomainEnum inDomain, InfoCategoryEnum inCategory)
        {
            var link = inEntity.Links.FirstOrDefault(u => u.InfoDomain == inDomain && u.InfoCategory == inCategory);
            if (link == null)
                throw new Exception("No url found in: " + inEntity.Name + " for domain: " + inDomain + " and category: " + inCategory);

            SetParameter("Uri", link.ToString());
        }
    }
}
