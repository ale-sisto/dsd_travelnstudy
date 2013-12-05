//using FluentNHibernate.Mapping;
//using StudyAbroad.DomainModel.Core;

//namespace StudyAbroad.DomainModel.Mapping.MappingIndividual
//{
//    public class LocationMap : ClassMap<Location>
//    {
//        LocationMap()
//        {
//            Id(x => x.Id).GeneratedBy.HiLo("0");
//            Map(x => x.Code).Unique();
//            Map(x => x.Name).Not.Nullable().Length(100);
//            References(x => x.ContainedBy).Not.LazyLoad();
//            HasMany(x => x.Links).Not.LazyLoad();
//        }
//    }

//    public class CityUSAMap : SubclassMap<CityUSA>
//    {
//        public CityUSAMap()
//        {
//        }
//    }

//    public class CityWorldMap : SubclassMap<CityWorld>
//    {
//        public CityWorldMap()
//        {
//        }
//    }

//    public class CountryMap : SubclassMap<Country>
//    {
//        public CountryMap()
//        {
//        }
//    }

//    public class StateMap : SubclassMap<State>
//    {
//        public StateMap()
//        {
//        }
//    }

//    class RegionMap : SubclassMap<Region>
//    {
//        public RegionMap()
//        {
//        }
//    }

//    public class ContinentMap : SubclassMap<Continent>
//    {
//        public ContinentMap()
//        {
//        }
//    }

//    public class UniversityMap : SubclassMap<University>
//    {
//        public UniversityMap()
//        {
//        }
//    }

//}
