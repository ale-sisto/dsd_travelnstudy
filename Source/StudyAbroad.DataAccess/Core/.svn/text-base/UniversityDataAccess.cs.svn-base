using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate.Linq;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.DataAccess.Core
{
    public class UniversityDataAccess : DataAccess.Framework.DataAccessORM<University>
    {
        public virtual List<int> ReadAllIds()
        {
            List<int> all = null;
            Transaction(session =>
            {
                all = session.Query<University>().OrderBy(u => u.Info.GlobalRank).Select(u => u.Id).ToList();
            });
            return all;
        }

        public virtual List<University> ReadOrderedByRank(int inLimit = 10)
        {
            List<University> all = null;
            Transaction(session =>
                            {
                                all = session.Query<University>().OrderBy(u => u.Info.GlobalRank).Take(inLimit).ToList();
                            });
            return all;
        }
        public virtual List<University> ReadOrderedByRank(Location inLocation, int inLimit = 10)
        {
            if (inLocation is Continent)
                return ReadOrderedByRankContinent(inLocation as Continent, inLimit);
            if (inLocation is Region)
                return ReadOrderedByRankRegion(inLocation as Region, inLimit);
            if (inLocation is Country)
                return ReadOrderedByRankCountry(inLocation as Country, inLimit);
            if (inLocation is State)
                return ReadOrderedByRankState(inLocation as State, inLimit);
            if (inLocation is City)
                return ReadOrderedByRankCity(inLocation as City, inLimit);
            return ReadOrderedByRank(inLimit);
        }

        private List<University> ReadOrderedByRankCity(City inCity, int inLimit)
        {
            List<University> all = null;
            Transaction(session =>
            {
                all =
                    session.Query<University>().Where(
                        u => u.ContainedBy == inCity).
                        OrderBy(u => u.Info.GlobalRank).Take(inLimit).ToList();
            });
            return all;
        }
        private List<University> ReadOrderedByRankState(State inState, int inLimit)
        {
            List<University> all = null;
            Transaction(session =>
            {
                all =
                    session.Query<University>().Where(
                        u => u.ContainedBy.ContainedBy == inState).
                        OrderBy(u => u.Info.GlobalRank).Take(inLimit).ToList();
            });
            return all;
        }
        private List<University> ReadOrderedByRankCountry(Country inCountry, int inLimit)
        {
            List<University> all = null;
            Transaction(session =>
            {
                all =
                    session.Query<University>().Where(
                        u => u.ContainedBy.ContainedBy == inCountry ||
                            u.ContainedBy.ContainedBy.ContainedBy == inCountry).
                        OrderBy(u => u.Info.GlobalRank).Take(inLimit).ToList();
            });
            return all;
        }
        private List<University> ReadOrderedByRankRegion(Region inRegion, int inLimit)
        {
            List<University> all = null;
            Transaction(session =>
            {
                all =
                    session.Query<University>().Where(
                        u => u.ContainedBy.ContainedBy.ContainedBy == inRegion ||
                            u.ContainedBy.ContainedBy.ContainedBy.ContainedBy == inRegion).
                        OrderBy(u => u.Info.GlobalRank).Take(inLimit).ToList();
            });
            return all;
        }
        private List<University> ReadOrderedByRankContinent(Continent inContinent, int inLimit)
        {
            List<University> all = null;
            Transaction(session =>
                            {
                                all =
                                    session.Query<University>().Where(
                                        u => u.ContainedBy.ContainedBy.ContainedBy.ContainedBy == inContinent ||
                                            u.ContainedBy.ContainedBy.ContainedBy.ContainedBy.ContainedBy == inContinent).
                                        OrderBy(u => u.Info.GlobalRank).Take(inLimit).ToList();
                            });
            return all;
        }
    }
}
