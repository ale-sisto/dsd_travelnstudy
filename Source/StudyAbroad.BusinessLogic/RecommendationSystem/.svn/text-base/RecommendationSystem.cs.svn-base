using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MyMediaLite;
using MyMediaLite.Data;
using StudyAbroad.BusinessLogic.RecommendationSystem.Utils;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Core;
using Random = System.Random;

namespace StudyAbroad.BusinessLogic.RecommendationSystem
{
    public sealed class RecommendationSystem
    {
        private static Random _random = new MyMediaLite.Random();
        private static Recommender _recommender;
        private static Recommender Recommender
        {
            get
            {
                if (_recommender == null)
                    _recommender = RecommendationSystem.Handler.InitRecommender();
                return _recommender;
            }
        }
        private static IRatings _ratings;
        private static IRatings Ratings
        {
            get
            {
                if (_ratings == null)
                    _ratings = RecommendationSystem.Handler.GetRatings();
                return _ratings;
            }
        }
        public static RecommendationSystem Handler
        {
            get
            {
                return Nested.ReccSystemHandler;
            }
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly RecommendationSystem ReccSystemHandler =
                new RecommendationSystem();
        }

        private IRatings GetRatings()
        {
            //Rating entries can be fetched in various ways
            var ratingEntries = GetRatingEntriesFakeUsersRealUnis();

            //Creating ratings from rating entries
            var ratings = new Ratings();
            foreach (var ratingEntry in ratingEntries)
            {
                int user_id = ratingEntry.UserId;
                int item_id = ratingEntry.ItemId;
                float rating = ratingEntry.Rating;

                ratings.Add(user_id, item_id, rating);
            }
            ratings.InitScale();
            return ratings;         
        }

        private List<RatingEntry> GetRatingEntriesFake()
        {
            var ratingEntries = new List<RatingEntry>();
            for (int i = 0; i < 5000; i++)
            {
                var userId = _random.Next(500);
                var itemId = _random.Next(500);
                if (ratingEntries.Count(r => r.UserId == userId && r.ItemId == itemId) != 0)
                    continue;
                var rating = _random.Next(5) + 1;
                ratingEntries.Add(new RatingEntry(userId, itemId, rating));

            }
            return ratingEntries;
        }

        private List<RatingEntry> GetRatingEntriesDB()
        {
            var reviews = BLLFactory.Reviews().GetAllUniversityRatings();
            return reviews.Select(review => new RatingEntry(review.Author.Id, review.Subject.Id, review.Rating)).ToList();
        }

        private List<RatingEntry> GetRatingEntriesFakeUsersRealUnis()
        {
            var universitiIds = BLLFactory.University().GetAllIds();
            var ratingEntries = new List<RatingEntry>();
            for (var i = 0; i < 12000; i++)
            {
                var randomUniversityLocationInList = _random.Next(universitiIds.Count);
                var itemId = universitiIds[randomUniversityLocationInList];
                var userId = _random.Next(48820, 48820 + 100);
                if (ratingEntries.Count(r => r.UserId == userId && r.ItemId == itemId) != 0)
                    continue;
                var rating = _random.Next(5) + 1;
                ratingEntries.Add(new RatingEntry(userId, itemId, rating));
            }
            return ratingEntries;
        }

        private Recommender InitRecommender()
        {
            var recommender = new MyMediaLite.RatingPrediction.SlopeOne();
            recommender.Ratings = Ratings;

            try
            {
                if (HttpContext.Current != null)
                    recommender.LoadModel(HttpContext.Current.Server.MapPath("model.dat"));
                else
                    recommender.LoadModel("model.dat");
            }
            catch
            {
                BuildModel();
                if (HttpContext.Current != null)
                    recommender.LoadModel(HttpContext.Current.Server.MapPath("model.dat"));
                else
                    recommender.LoadModel("model.dat");
            }
            return recommender;
        }

        public void BuildModel()
        {
            var recommender = new MyMediaLite.RatingPrediction.SlopeOne();
            recommender.Ratings = Ratings;

            recommender.Train();
            if (HttpContext.Current != null)
                recommender.SaveModel(HttpContext.Current.Server.MapPath("model.dat"));
            else
                recommender.SaveModel("model.dat");
        }

        public float Predict(int userId, int itemId)
        {
           return Recommender.Predict(userId, itemId);
        } 

        private IList<Tuple<int, float>> Recommend(int userId, int limit)
        {
            return Recommender.Recommend(userId, limit);
        }

        public List<University> RecommendUnis(int userId, int limit = 10)
        {
            var recommendations = Recommend(userId, limit);
            var unis = BLLFactory.University().GetByIdMany(recommendations.Select(r => r.Item1).ToList());
            return unis;
        }

        public List<University> RecommendUnis(int userId, List<University> unis)
        {
            BuildModel();
            var uniPredictionTupleList = unis.Select(uni => new Tuple<University, float>(uni, Predict(userId, uni.Id))).ToList();
            uniPredictionTupleList = uniPredictionTupleList.OrderByDescending(up => up.Item2).ToList();
            return uniPredictionTupleList.Select(up => up.Item1).ToList();
        }
    }
}
