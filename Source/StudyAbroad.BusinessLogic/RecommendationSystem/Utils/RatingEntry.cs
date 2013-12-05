using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.BusinessLogic.RecommendationSystem.Utils
{
    public class RatingEntry
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Rating { get; set; }

        public RatingEntry(int userId, int itemId, int rating)
        {
            UserId = userId;
            ItemId = itemId;
            Rating = rating;
        }
    }
}
