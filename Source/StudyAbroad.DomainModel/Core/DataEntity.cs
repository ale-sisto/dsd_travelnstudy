using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.DomainModel.Framework;

namespace StudyAbroad.DomainModel.Core
{
    public abstract class DataEntity : DomainBase<DataEntity>
    {
        public virtual string Name { get; set; }
        public virtual IList<Uri> Links { get; set; }

        public DataEntity(string inName)
        {
            Name = inName;
            Links = new List<Uri>();
        }

        public DataEntity()
        {
            Links = new List<Uri>();
        }

        public virtual void RegisterDataSource(Enums.InfoDomainEnum inDomain, Enums.InfoCategoryEnum inCategory, string inUri)
        {
            var existing = Links.FirstOrDefault(l => l.InfoDomain == inDomain && l.InfoCategory == inCategory);
            if (existing != null)
            {
                if (existing.Uris.Contains(inUri))
                    throw new Exception("This object already has this url defined");
                existing.Uris.Add(inUri);
            }
            else
            {
                var uri = new Uri(inDomain, inCategory, inUri);
                Links.Add(uri);
            }
        }

        public virtual Uri GetLink(Enums.InfoDomainEnum inDomain, Enums.InfoCategoryEnum inCategory)
        {
            var link = Links.FirstOrDefault(l => l.InfoDomain == inDomain && l.InfoCategory == inCategory);
            if (link == null) throw new Exception("No such link");
            return link;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual string Display()
        {
            return ToString();
        }
    }
}
