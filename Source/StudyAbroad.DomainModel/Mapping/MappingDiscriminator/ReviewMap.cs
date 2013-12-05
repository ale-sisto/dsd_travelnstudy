using FluentNHibernate.Mapping;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DomainModel.Mapping.MappingDiscriminator
{
    public class ReviewMap : ClassMap<Review>
    {
        public ReviewMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0");
            Map(x => x.Comment).Not.Nullable().Length(1000);
            Map(x => x.Rating).Not.Nullable();
            Map(x => x.DateTime).Not.Nullable();
            References(x => x.Subject).Not.Nullable();
            References(x => x.Author).Not.Nullable();
        }
    }
}
