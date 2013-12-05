using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DataAccess.Core;
using StudyAbroad.DomainModel;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DynamicLoading.Factories;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.BusinessLogic.Core
{
    /// <summary>
    /// Wrapper for the Data Access Layer for fetching universities.
    /// </summary>
    public class UniversityBusinessLogic : Framework.BusinessLogic<University>
    {
        private UniversityDataAccess _ormDal;

        public UniversityBusinessLogic()
        {
            _ormDal = new UniversityDataAccess();
        }

        public List<int> GetAllIds()
        {
            return _ormDal.ReadAllIds();
        }

        public University GetById(int id)
        {
            return Orm.ReadId(id);
        }

        public List<University> GetByIdMany(List<int> ids)
        {
            return ids.Select(GetById).ToList();
        }

        public University GetByName(string inName)
        {
            return Orm.FilterFirst(u => u.Name == inName);
        }

        public List<University> GetTopAll()
        {
            return _ormDal.ReadOrderedByRank(99999);
        }

        public List<University> GetTopByLocation(Location inLocation)
        {
            return _ormDal.ReadOrderedByRank(inLocation);
        }

        public List<University> GetTopByLocation(Location inLocation, int inCount)
        {
            return _ormDal.ReadOrderedByRank(inLocation, inCount);
        }

        public List<University> GetTopByLocationCode(string inCode)
        {
            var location = BLLFactory.Location().GetByCode(inCode);
            return GetTopByLocation(location);
        }

        public List<University> GetTopByLocationCode(string inCode, int inCount)
        {
            var location = BLLFactory.Location().GetByCode(inCode);
            return GetTopByLocation(location, inCount);
        }

        public List<University> GetTopByLocationName(string inName)
        {
            var location = BLLFactory.Location().GetByName(inName);
            return GetTopByLocation(location);
        }

        public List<University> GetTopByLocationName(string inName, int inCount)
        {
            var location = BLLFactory.Location().GetByName(inName);
            return GetTopByLocation(location, inCount);
        }

        public void UpdateMany(List<University> inUniversities, bool inFullUpdate)
        {
            foreach (var inUniversity in inUniversities)
            {
                if (inFullUpdate)
                    UpdateFullInfo(inUniversity);
                else
                    UpdateShortInfo(inUniversity);
            }
        }

        public void UpdateInfo(University inUniversity, ParameterCollection inParameters)
        {
            try
            {
                Odsm.Update(LoaderFactory.Freebase().Updaters().University().Info(inUniversity), inUniversity, inParameters);
            }
            catch (Exception e)
            {
                if (e.Message == "Search returned with no results!")
                    return;
                throw;
            }
        }

        public void UpdateFullInfo(University inUniversity)
        {
            var pars = new UniversityParameters().GetAllProperties();
            UpdateInfo(inUniversity, pars);
        }

        public void UpdateShortInfo(University inUniversity)
        {
            var pars = new UniversityParameters().GetShortProperties();
            UpdateInfo(inUniversity, pars);
        }

        public List<KeyValuePair<string, int>> GetAllLocationsRank(University inUniversity)
        {
            var list = new List<KeyValuePair<string, int>>();
            GetAllLocationsRank(inUniversity, inUniversity.ContainedBy.ContainedBy, list);
            list.Add(new KeyValuePair<string, int>("World", inUniversity.Info.GlobalRank));
            return list;
        }

        public void GetAllLocationsRank(University inUniversity, Location inLocation, List<KeyValuePair<string, int>> inList)
        {
            if (inLocation != null && inLocation.Code != "world")
            {
                var locationUnis = GetTopByLocation(inLocation.Self, 99999);
                var rank = locationUnis.IndexOf(inUniversity) + 1;
                inList.Add(new KeyValuePair<string, int>(inLocation.Name, rank));
                GetAllLocationsRank(inUniversity, inLocation.ContainedBy, inList);
            }
        }

        public void getAVGRank(Location inLoc, int setSize, List<String> res)
        {
            if (inLoc != null && inLoc.Code != "world")
            {
                var mylist = GetTopByLocation(inLoc.Self, setSize);

                int avg = 0;
                /* Let's do this for undergraduate prices first */
                for (int i = 0; i < mylist.Count; i++)
                {
                    avg += mylist[i].Info.GlobalRank;
                }

                if (mylist.Count > 0) avg /= mylist.Count;

                res.Add(inLoc.Name);
                res.Add(avg.ToString());
                getAVGRank(inLoc.ContainedBy, setSize, res);
            }
        }

        public List<String> getAVGRank(University inUniversity)
        {
            var res = new List<String>();
            int setSize = 30;
            getAVGRank(inUniversity.ContainedBy.ContainedBy, setSize, res);
            return res;
        }

        private int ParseCostString(String tempunder)
        {
            try
            {
                if (tempunder.StartsWith("Not "))
                {
                    return 0;
                }
                else if (tempunder.StartsWith("over"))
                {
                    var index = tempunder.IndexOf(" ");
                    var index2 = tempunder.IndexOf("U");
                    var value = tempunder.Substring(index + 1, index2 - index - 2).Replace(",", "");
                    return int.Parse(value);
                }
                else
                {
                    var index = tempunder.IndexOf("-");
                    var index2 = tempunder.IndexOf("U");
                    var min = tempunder.Substring(0, index).Replace(",", "");
                    var max = tempunder.Substring(index + 1, index2 - index - 2).Replace(",", "");
                    return ((int.Parse(min) + int.Parse(max)) / 2);
                }
            }
            catch (Exception e)
            {
                return 0;
            };
        }

        public List<String> getAVGCosts(University inUniversity)
        {
            var res = new List<String>();
            int setSize = 30;
            getAVGCosts(inUniversity.ContainedBy.ContainedBy, setSize, res);
            return res;
        }

        public void getAVGCosts(Location inLoc, int setSize, List<String> res)
        {
            if (inLoc != null && inLoc.Code != "world")
            {
                var mylist = GetTopByLocation(inLoc.Self, setSize);
                int avg = 0, count = 0, temp;
                /* Let's do this for undergraduate prices first */
                for (int i = 0; i < mylist.Count; i++)
                {
                    temp = ParseCostString(mylist[i].Info.InternationalStudentsUnderGraduatePrice);
                    if (temp > 0)
                    {
                        count++;
                        avg += temp;
                    }
                }
                if (count > 0) avg /= count;

                res.Add(inLoc.Name);
                res.Add(avg.ToString());
                count = avg = 0;
                /* Now the same for postgraduate */
                for (int i = 0; i < mylist.Count; i++)
                {
                    temp = ParseCostString(mylist[i].Info.InternationalStudentsPostGraduatePrice);
                    if (temp > 0)
                    {
                        count++;
                        avg += temp;
                    }
                }
                if (count > 0) avg /= count;
                res.Add(avg.ToString());
                getAVGCosts(inLoc.ContainedBy, setSize, res);
            }
        }

    }
}
