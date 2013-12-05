//using FluentNHibernate.Mapping;
//using StudyAbroad.DomainModel.Core;

//namespace StudyAbroad.DomainModel.Mapping.MappingIndividual
//{
//    public class CommentsMap : ClassMap<Comments>
//    {
//        public CommentsMap()
//        {
//            Id(x => x.Id).GeneratedBy.HiLo("0");
//            Map(x => x.CommentText).Not.Nullable().Length(1000);
//            Map(x => x.DateTime).Not.Nullable();
//            References(x => x.Location).Not.Nullable().Not.LazyLoad();
//            References(x => x.User).Not.Nullable().Not.LazyLoad();
//        }
//    }
//}
