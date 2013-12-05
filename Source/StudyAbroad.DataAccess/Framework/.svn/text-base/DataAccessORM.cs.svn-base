using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using StudyAbroad.DataAccess.Configurations;
using StudyAbroad.DataAccess.Exceptions;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DataAccess.Framework
{
    public class DataAccessORM<T> : IDataAccess<T>
    {
        public virtual List<T> ReadAll()
        {
            List<T> all = null;
            Transaction(session =>
                            {
                                all = session.Query<T>().ToList();
                            });
            return all;
        }

        public virtual List<T> ReadCount(int count)
        {
            List<T> all = null;
            Transaction(session =>
            {
                all = session.Query<T>().Take(count).ToList();
            });
            return all;
        }

        public virtual T ReadId(int id)
        {
            var obj = default(T);
            Transaction(session =>
                            {
                                obj = session.Get<T>(id);
                            });

            return obj;
        }

        public virtual List<T> FilterAll(Func<T, bool> predicate)
        {
            List<T> all = null;
            Transaction(session =>
                            {
                                all = session.Query<T>().Where(predicate).ToList();
                            });

            return all;
        }

        public virtual List<T> FilterCount(Func<T, bool> predicate, int count)
        {
            return FilterAll(predicate).Take(count).ToList();
        }


        public virtual T FilterFirst(Func<T, bool> predicate)
        {
            return FilterAll(predicate).FirstOrDefault();
        }

        public virtual void Create(T obj)
        {
            Transaction(session => session.SaveOrUpdate(obj));
        }

        public void CreateMany(List<T> objs)
        {
            foreach (var obj in objs)
            {
                Create(obj);
            }
        }

        public void UpdateMany(List<T> objs)
        {
            CreateMany(objs);
        }

        public virtual void Update(T obj)
        {
            Transaction(session => session.SaveOrUpdate(obj));
        }

        public virtual void Delete(T obj)
        {
            Transaction(session => session.Delete(obj));
        }

        public virtual void Delete(int id)
        {
            Delete(ReadId(id));
        }

        protected void Transaction(Action<ISession> action)
        {
            NHibernateSessionManager.Instance.BeginTransaction();        
            try
            {
                action(NHibernateSessionManager.Instance.GetSession());
                NHibernateSessionManager.Instance.CommitTransaction();
            }
            catch (Exception e)
            {
                NHibernateSessionManager.Instance.RollbackTransaction();
                throw new Exception("NHibernate transaction error! Message: " + e.Message);
            }

        }

        //private void Transaction(Action<ISession> action)
        //{
        //    using (var tx = DataBaseConfiguration.Session.BeginTransaction())
        //    {
        //        try
        //        {
        //            action(DataBaseConfiguration.Session);
        //            tx.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            tx.Rollback();
        //            throw new Exception("NHibernate transaction error! Message: " + e.Message);
        //        }
        //    }
        //}


        public T ReadFirst()
        {
            return ReadAll().First();
        }


        public void Load(DynamicLoading.Framework.Loader<T> inNewLoader)
        {
            throw new DataAccessInvalidActionException("Not possible to cache (load) the database (only external sources). Check your data access provider!");
        }


        public void Update(DynamicLoading.Framework.Loader<T> inLoader, T obj, ParameterCollection parameters)
        {
            throw new DataAccessInvalidActionException("Not possible to update the object with the loader. Check your data access provider!");
        }
    }
}
