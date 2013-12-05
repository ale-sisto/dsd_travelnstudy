using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DomainModel.Mapping.MappingDiscriminator
{
    public class DataEntityMap : ClassMap<DataEntity>
    {
        public DataEntityMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("0");
            Map(x => x.Name).Not.Nullable().Length(100);
            HasMany(x => x.Links).Cascade.All();

            DiscriminateSubClassesOnColumn("EntityType").Not.Nullable();
        }
    }
}
