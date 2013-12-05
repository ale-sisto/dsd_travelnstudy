using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DataAccess.Resources.Readers;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DataAccess.Core
{
    public class LocalDataAccess
    {
        private Resources.Readers.IsoLocationsReader _reader = new IsoLocationsReader();

        public Location GetWorldLocal()
        {
            return _reader.World;
        }

        public List<Continent> GetContinentsLocal()
        {
            return _reader.Continents;
        }

        public List<Region> GetRegionsLocal()
        {
            return _reader.Regions;
        }

        public List<Country> GetCountriesLocal()
        {
            return _reader.Countries;
        }

        public List<State> GetStatesLocal()
        {
            return _reader.States;
        }
    }
}
