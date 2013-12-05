using System.Collections.Generic;
using StudyAbroad.DomainModel.Framework;
using StudyAbroad.DomainModel.Exceptions;

namespace StudyAbroad.DomainModel.Core
{
    public class Uri : DomainBase<Uri>
    {
        public virtual Enums.InfoDomainEnum InfoDomain { get; set; }
        public virtual Enums.InfoCategoryEnum InfoCategory { get; set; }      
        public virtual List<string> Uris { get; set; }
        public virtual string DefaultUri { get; set; }

        public Uri(Enums.InfoDomainEnum inDomain, Enums.InfoCategoryEnum inCategory, string inUriString)
        {
            if(string.IsNullOrEmpty(inUriString)||string.IsNullOrWhiteSpace(inUriString))
                throw new DomainModelValidationException("Uri string can not be empty.", "inUriString");

            InfoDomain = inDomain;
            InfoCategory = inCategory;
            Uris = new List<string> {inUriString};
            DefaultUri = inUriString;
        }

        public Uri(Enums.InfoDomainEnum inDomain, Enums.InfoCategoryEnum inCategory, List<string> inUris)
        {
            if (inUris == null || inUris.Count == 0)
                throw new DomainModelValidationException("Uri list can not be empty.", "inUris");
            
            InfoDomain = inDomain;
            InfoCategory = inCategory;
            Uris = inUris;
            DefaultUri = Uris[0];
        }

        public Uri()
        {}

        public override string ToString()
        {
            return DefaultUri;
        }

        public virtual string Display()
        {
            return ToString();
        }
    }
}
