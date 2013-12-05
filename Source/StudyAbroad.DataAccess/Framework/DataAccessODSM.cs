using System;
using System.Collections.Generic;
using System.Linq;
using StudyAbroad.DataAccess.Exceptions;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DataAccess.Framework
{
    /// <summary>
    /// Generic data access layer, when created uses a loader to load data into a temporary cache, then provides methods to fetch that data
    /// </summary>
    /// <typeparam name="T">One of the domain types</typeparam>
    public class DataAccessODSM<T> : IDataAccess<T>
    {
        private List<T> _cache = new List<T>();

        public DataAccessODSM()
        {}

        public DataAccessODSM (Loader<T> inLoader)
        {
            inLoader.Load(_cache);
        }

        public List<T> ReadAll()
        {
            return _cache;
        }

        public List<T> ReadCount(int inCount)
        {
            return _cache.Take(inCount).ToList();
        }

        public T ReadFirst()
        {
            return _cache.First();
        }

        public List<T> FilterAll(Func<T, bool> inFilter)
        {
            return _cache.Where(inFilter).ToList();
        }

        public List<T> FilterCount(Func<T, bool> inFilter, int inCount)
        {
            return _cache.Where(inFilter).Take(inCount).ToList();
        }

        public T FilterFirst(Func<T, bool> inFilter)
        {
            return _cache.Where(inFilter).First();
        }


        public T ReadId(int id)
        {
            throw new DataAccessInvalidActionException("Not possible to read from id with external data sources. Check your data access provider!");
        }

        public void Create(T obj)
        {
            throw new DataAccessInvalidActionException("Not possible to write to external data sources. Check your data access provider!");
        }

        public void CreateMany(List<T> objs)
        {
            throw new DataAccessInvalidActionException("Not possible to write to external data sources. Check your data access provider!");
        }

        public void Update(T obj)
        {
            throw new DataAccessInvalidActionException("Not possible to update external data sources. Check your data access provider!");
        }

        public void UpdateMany(List<T> objs)
        {
            throw new DataAccessInvalidActionException("Not possible to update external data sources. Check your data access provider!");
        }

        public void Delete(T obj)
        {
            throw new DataAccessInvalidActionException("Not possible to delete from external data sources. Check your data access provider!");
        }

        public void Delete(int id)
        {
            throw new DataAccessInvalidActionException("Not possible to delete from external data sources. Check your data access provider!");
        }


        public void Load(Loader<T> inNewLoader)
        {
            _cache = new List<T>();
            inNewLoader.Load(_cache);
        }


        public void Update(Loader<T> inLoader, T obj, ParameterCollection parameters)
        {
            inLoader.Update(obj, parameters);
        }
    }
}
