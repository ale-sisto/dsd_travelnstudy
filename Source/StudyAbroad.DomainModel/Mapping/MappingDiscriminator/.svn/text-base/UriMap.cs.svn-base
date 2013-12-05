using FluentNHibernate.Mapping;

namespace StudyAbroad.DomainModel.Mapping.MappingDiscriminator
{
    public class UriMap : ClassMap<Core.Uri>
    {
        public UriMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0");
            Map(x => x.InfoDomain);
            Map(x => x.InfoCategory);
            Map(x => x.DefaultUri).Not.Nullable().Length(200);
            Map(x => x.Uris).Not.Nullable();
        }
    }
}
