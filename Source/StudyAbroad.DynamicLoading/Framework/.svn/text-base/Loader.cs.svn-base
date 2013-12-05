using System.Collections.Generic;

namespace StudyAbroad.DynamicLoading.Framework
{
    /// <summary>
    /// Loader interface
    /// Loader needs to be suplied with the loading configuration
    /// </summary>
    /// <typeparam name="T">One of domain types</typeparam>
    public abstract class Loader<T>
    {
        protected LoaderConfiguration Configuration { get; private set; }

        protected Loader(LoaderConfiguration inConfiguration)
        {
            Configuration = inConfiguration;
        }

        public abstract void Load(List<T> items);

        public abstract void Update(T obj, ParameterCollection parameters);
    }
}
