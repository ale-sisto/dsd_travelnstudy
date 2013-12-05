using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using StudyAbroad.DataAccess.Framework;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.DataAccess.Core
{
    public class LocationDataAccess : DataAccessORM<Location>
    {
        public virtual Location GetByCode(string inCode)
        {
            Location location = null;
            Transaction(session =>
            {
                location = session.Query<Location>().Where(l => l.Code == inCode).ToList().FirstOrDefault();
            });
            return location;
        }

        public virtual Location GetByName(string inName)
        {
            Location location = null;
            Transaction(session =>
            {
                location = session.Query<Location>().Where(l => l.Name == inName).ToList().FirstOrDefault();
            });
            return location;
        }

        public virtual List<Location> GetByNameMany(string inName)
        {
            var locations = new List<Location>();
            Transaction(session =>
            {
                locations = session.Query<Location>().Where(l => l.Name == inName).ToList();
            });
            return locations;
        }

        public virtual List<Location> GetByContainedBy(Location inContainedBy)
        {
            var locations = new List<Location>();
            Transaction(session =>
            {
                locations = session.Query<Location>().Where(l => l.ContainedBy == inContainedBy).ToList();
            });
            return locations;
        }
    }
}
