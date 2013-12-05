using System;
using System.Collections.Generic;
using StudyAbroad.DataAccess;
using StudyAbroad.DataAccess.Core;
using StudyAbroad.DataAccess.Framework;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.BusinessLogic.Framework
{
    public class ODSMInterface<T>
    {
        private IDataAccess<T> _dal;

        public ODSMInterface()
        {
            _dal = new DataAccessODSM<T>();
        }

        public List<T> ReadAll(Loader<T> inLoader)
        {
            _dal.Load(inLoader);
            return _dal.ReadAll();
        }

        public List<T> ReadCount(Loader<T> inLoader, int inCount)
        {
            _dal.Load(inLoader);
            return _dal.ReadCount(inCount);
        }

        public T ReadFirst(Loader<T> inLoader)
        {
            _dal.Load(inLoader);
            return _dal.ReadFirst();
        }

        public List<T> FilterAll(Loader<T> inLoader, Func<T, bool> inFilter)
        {
            _dal.Load(inLoader);
            return _dal.FilterAll(inFilter);
        }

        public List<T> FilterCount(Loader<T> inLoader, Func<T, bool> inFilter, int inCount)
        {
            _dal.Load(inLoader);
            return _dal.FilterCount(inFilter, inCount);
        }

        public T FilterFirst(Loader<T> inLoader, Func<T, bool> inFilter)
        {
            _dal.Load(inLoader);
            return _dal.FilterFirst(inFilter);
        }

        public void Update(Loader<T> inLoader, T obj, ParameterCollection parameters)
        {
            _dal.Update(inLoader, obj, parameters);
        }
    }
}
