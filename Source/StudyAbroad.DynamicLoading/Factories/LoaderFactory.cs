using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.DynamicLoading.Factories
{
    public static class LoaderFactory
    {
        public static IcuOrgLoaderFactory IcuOrg()
        {
            return new IcuOrgLoaderFactory();
        }

        public static FreebaseLoaderFactory Freebase()
        {
            return new FreebaseLoaderFactory();
        }

        public static NumbeoFactory Numbeo()
        {
            return new NumbeoFactory();
        }

        public static DataBankClimateFactory DataBankClimate()
        {
            return  new DataBankClimateFactory();
        }
    }

    #region LoaderFactories

    #region IcuOrg
    public class IcuOrgLoaderFactory
    {
        public IcuOrgLoaderFactoryLoaders Loaders()
        {
            return new IcuOrgLoaderFactoryLoaders();
        }

        public IcuOrgLoaderFactoryUpdaters Updaters()
        {
            return new IcuOrgLoaderFactoryUpdaters();
        }
    } 
    #endregion

    #region Freebase
    public class FreebaseLoaderFactory
    {
        public FreebaseLoaderFactoryUpdaters Updaters()
        {
            return new FreebaseLoaderFactoryUpdaters();
        }
    }
    #endregion

    #endregion

    #region LoaderFactoryLoaders/Updaters

    #region IcuOrg
    public class IcuOrgLoaderFactoryLoaders
    {
        public IcuOrgUniversityLoaderFactory University()
        {
            return new IcuOrgUniversityLoaderFactory();
        }
    }

    public class IcuOrgLoaderFactoryUpdaters
    {
        public IcuOrgUniversityUpdaterFactory University()
        {
            return new IcuOrgUniversityUpdaterFactory();
        }
    }
    #endregion

    #region Freebase
    public class FreebaseLoaderFactoryUpdaters
    {
        public FreebaseUniversityUpdaterFactory University()
        {
            return new FreebaseUniversityUpdaterFactory();
        }

        public FreebaseCityUpdaterFactory City()
        {
            return new FreebaseCityUpdaterFactory();
        }
    } 
    #endregion

    #endregion

}
