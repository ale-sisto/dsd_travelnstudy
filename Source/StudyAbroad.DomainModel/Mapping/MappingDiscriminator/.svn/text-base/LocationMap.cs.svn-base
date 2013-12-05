using FluentNHibernate.Mapping;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DomainModel.Mapping.MappingDiscriminator
{
    public class LocationMap : SubclassMap<Location>
    {
        LocationMap()
        {
            Map(x => x.Code).Index("idxCode");
            References(x => x.ContainedBy);

            DiscriminatorValue(@"Location");
        }
    }

    public class CityUSAMap : SubclassMap<CityUSA>
    {
        public CityUSAMap()
        {
            DiscriminatorValue(@"CityUSA");
        }
    }

    public class CityWorldMap : SubclassMap<CityWorld>
    {
        public CityWorldMap()
        {
            DiscriminatorValue("CityWorld");
        }
    }

    public class CountryMap : SubclassMap<Country>
    {
        public CountryMap()
        {
            DiscriminatorValue("Country");
        }
    }

    public class StateMap : SubclassMap<State>
    {
        public StateMap()
        {
            DiscriminatorValue("State");
        }
    }

    class RegionMap : SubclassMap<Region>
    {
        public RegionMap()
        {
            DiscriminatorValue("Region");
        }
    }

    public class ContinentMap : SubclassMap<Continent>
    {
        public ContinentMap()
        {
            DiscriminatorValue("Continent");
        }
    }

    public class UniversityMap : SubclassMap<University>
    {
        public UniversityMap()
        {
            DiscriminatorValue("University");
            References(x => x.Info).Cascade.All();
        }
    }

}
