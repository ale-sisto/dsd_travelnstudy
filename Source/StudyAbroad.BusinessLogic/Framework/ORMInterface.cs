using System;
using System.Collections.Generic;
using StudyAbroad.DataAccess;
using StudyAbroad.DataAccess.Core;
using StudyAbroad.DataAccess.Framework;

namespace StudyAbroad.BusinessLogic.Framework
{
    public class ORMInterface<T>
    {
        private IDataAccess<T> _dal;

        public ORMInterface()
        {
            _dal = new DataAccessORM<T>();
        }

        public virtual List<T> ReadAll()
        {
            return _dal.ReadAll();
        }

        public virtual List<T> ReadCount(int count)
        {
            return _dal.ReadCount(count);
        }

        public virtual T ReadId(int id)
        {
            return _dal.ReadId(id);
        }

        public virtual List<T> FilterAll(Func<T, bool> predicate)
        {
            return _dal.FilterAll(predicate);
        }

        public virtual List<T> FilterCount(Func<T, bool> predicate, int count)
        {
            return _dal.FilterCount(predicate, count);
        }

        public virtual T FilterFirst(Func<T, bool> predicate)
        {
            return _dal.FilterFirst(predicate);
        }

        public virtual void Create(T obj)
        {
            _dal.Create(obj);
        }

        public virtual void CreateMany(List<T> objs)
        {
            _dal.CreateMany(objs);
        }

        public virtual void Update(T obj)
        {
            _dal.Update(obj);
        }
        
        public virtual void UpdateMany(List<T> objs)
        {
            _dal.UpdateMany(objs);
        }

        public virtual void Delete(T obj)
        {
            _dal.Delete(obj);
        }

        public virtual void Delete(int id)
        {
            _dal.Delete(id);
        }

        public T ReadFirst()
        {
            return _dal.ReadFirst();
        }
    }
}
