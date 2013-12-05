using FluentNHibernate.Mapping;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DomainModel.Mapping.MappingDiscriminator
{
    /// <summary>
    /// A sample map class for mapping the user to the database
    /// Follow this principle for other classes, if you get stuck contact me (BL) or just google it, there is a good reference on fluent nHibernate page
    /// </summary>
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0");
            Map(x => x.Name).Not.Nullable().Length(40);
            Map(x => x.Surname).Not.Nullable().Length(60);
            Map(x => x.Username).Not.Nullable().Unique().Length(20);
            Map(x => x.PassHash).Not.Nullable();
            References(x => x.Country).Not.Nullable();
            Map(x => x.Roles);
        }
    }
}
