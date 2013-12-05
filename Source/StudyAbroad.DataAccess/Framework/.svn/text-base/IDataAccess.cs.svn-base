using System;
using System.Collections.Generic;
using StudyAbroad.DynamicLoading.Framework;

namespace StudyAbroad.DataAccess.Framework
{
    public interface IDataAccess<T>
    {
        List<T> ReadAll();
        List<T> ReadCount(int count);
        T ReadId(int id);
        T ReadFirst();
        List<T> FilterAll(Func<T, bool> predicate);
        List<T> FilterCount(Func<T, bool> predicate, int count);
        T FilterFirst(Func<T, bool> predicate);
        void Create(T obj);
        void CreateMany(List<T> objs);
        void Update(T obj);
        void Update(Loader<T> inLoader, T obj, ParameterCollection parameters);
        void UpdateMany(List<T> objs);
        void Delete(T obj);
        void Delete(int id);
        void Load(Loader<T> inNewLoader);
    }
}
