using System;
using StudyAbroad.DomainModel.Framework;
using StudyAbroad.DomainModel.Exceptions;

namespace StudyAbroad.DomainModel.Core
{
    public  class Review : DomainBase<Review>
    {
        public virtual User Author { get; set; }
        public virtual string Comment { get; set; }
        public virtual int Rating { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual Location Subject { get; set; }

        public Review(User inUser, string inComment, int inRating, Location inSubject)
        {
            if (inUser == null)
                throw new DomainModelValidationException("The author of the review cannot be null", "inUser");
            if(inComment.Length<2 || inComment.Length > 1000)
                throw new DomainModelValidationException("Comment cannot be empty and must be between 2 and 1000 characters", "inCommentText");
            if(inRating<1 || inRating>5)
                throw new DomainModelValidationException("Rating must be a number between 1 and 5", "inRating");
            if (inSubject == null || !(inSubject is IReviewable))
                throw new DomainModelValidationException("The subject of the review must be specified and must be reviewable (City or University)", "inSubject");
            
            Author = inUser;
            Comment = inComment;
            Rating = inRating;
            DateTime = DateTime.Now;
            Subject = inSubject;
        }

        public Review()
        {}

        public override string ToString()
        {
            if (Comment.Length > 40)
                return "On "+DateTime+" user "+Author.Username+" wrote: "+Comment.Substring(0, 40) +"...";
            return "On " + DateTime + " user " + Author.Username + " wrote: " + Comment;
        }

        public virtual string Display()
        {
            return ToString();
        }
    }
}
