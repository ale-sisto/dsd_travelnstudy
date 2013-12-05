namespace StudyAbroad.BusinessLogic.Framework
{
    public class BusinessLogic<T>
    {
        protected readonly ODSMInterface<T> Odsm;
        protected readonly ORMInterface<T> Orm;

        protected BusinessLogic()
        {
            Odsm = new ODSMInterface<T>();
            Orm = new ORMInterface<T>();
        }
    }
}
