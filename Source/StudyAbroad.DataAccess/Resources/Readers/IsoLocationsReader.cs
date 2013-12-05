using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DataAccess.Resources.Readers
{
    public class IsoLocationsReader
    {
        private Location _world = new Location("world", "World", null);
        private List<Continent> _continents = new List<Continent>();
        private List<Region> _regions = new List<Region>();
        private List<Country> _countries = new List<Country>(); 
        private List<State> _states = new List<State>();

        public Location World { get { return _world; } }
        public List<Continent> Continents { get { return _continents; } }
        public List<Region> Regions { get { return _regions; } } 
        public List<Country> Countries { get { return _countries; } }
        public List<State> States { get { return _states; } } 
       
        public IsoLocationsReader()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetLocationsFromResource();
            UpdateCountriesFromXml();
            var usa = _countries.First(c => c.Code == "US");
            SetStatesFromResource(usa);
        }

        private void SetLocationsFromResource()
        {
            var continentsSplit = Resources.Content.IsoLocations.Locations.Split('&');
            foreach (var split in continentsSplit)
            {
                var continentSection = split.Split('#')[0];
                var regionSection = split.Split('#')[1];

                var continentCode = continentSection.Split('-')[0];
                var continentName = continentSection.Split('-')[1];

                var continent = new Continent(continentCode, continentName, _world);
                _continents.Add(continent);

                foreach (var regionSplit in regionSection.Split('|'))
                {
                    var regionCode = regionSplit.Split(':')[0].Split('-')[0];
                    var regionName = regionSplit.Split(':')[0].Split('-')[1];

                    var region = new Region(regionCode, regionName, continent);
                    _regions.Add(region);

                    foreach (var countryCode in regionSplit.Split(':')[1].Split(','))
                    {
                        var country = new Country(countryCode, null, region);
                        _countries.Add(country);
                    }
                }
            }
        }

        private void UpdateCountriesFromXml()
        {
            var xmlCountries = ReadCountriesFromIsoXml();
            foreach (var country in _countries)
            {
                var xmlCountry = xmlCountries.FirstOrDefault(x => x.Code == country.Code);
                if (xmlCountry == null)
                    continue;
                country.Name = xmlCountry.Name;
            }

            _countries.RemoveAll(c => c.Name == null);
        }

        private void SetStatesFromResource(Country inUSA)
        {
            var statesResource = Resources.Content.IsoLocations.States;
            foreach (var stateSection in statesResource.Split('#'))
            {
                var stateCode = stateSection.Split(':')[0];
                var stateName = stateSection.Split(':')[1];

                var state = new State(stateCode, stateName, inUSA);
                _states.Add(state);
            }
        }

        private List<Country> ReadCountriesFromIsoXml()
        {
            var returnedList = new List<Country>();

            var xml = new XmlDocument();
            xml.Load(Resources.Content.Uris.IsoLocationsXml);

            var xmlNodeList = xml.SelectNodes("ISO_3166-1_List_en/ISO_3166-1_Entry");
            if (xmlNodeList != null)
                foreach (XmlNode node in xmlNodeList)
                {
                    var countryCode = node.SelectSingleNode("ISO_3166-1_Alpha-2_Code_element").InnerText;
                    var countryName = node.SelectSingleNode("ISO_3166-1_Country_name").InnerText.ToLower();

                    var country = new Country(countryCode, Capitalize(countryName), null);
                    returnedList.Add(country);
                }

            return returnedList;
        }

        private string Capitalize(string inText)
        {
            var parts = inText.Split(' ');
            var newString = "";
            foreach (var part in parts)
            {
                if (new string[] { "and", "of", "the" , "da"}.Contains(part))
                    newString += part + " ";
                else
                    if (part[0] == '(')
                        newString += part[0].ToString(CultureInfo.InvariantCulture) + char.ToUpper(part[1]).ToString(CultureInfo.InvariantCulture) + part.Substring(2) + " ";
                    else
                        newString += char.ToUpper(part[0]) + part.Substring(1) + " ";
            }
            return newString.Trim(new char[] { ' ' });
        }
    }
}
