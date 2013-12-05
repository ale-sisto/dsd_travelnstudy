using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.BusinessLogic.Core
{
    public class ReviewBusinessLogic : BusinessLogic.Framework.BusinessLogic<Review>
    {
        public void Add(Review review)
        {
            Orm.Create(review);
        }

        public Review Add(string username, string comment, int rating, string subjectName)
        {
            var existingReview = GetByUserSubject(username, subjectName);
            if (existingReview != null)
                throw new Exception("There already exists a review for that user on that subject. Either remove the old review to add a new one or modify existing.");

            var user = BLLFactory.User().GetByUsername(username);
            var subject = BLLFactory.Location().GetByName(subjectName);      

            var review = new Review(user, comment, rating, subject);
            Add(review);
            return review;
        }

        public List<Review> GetAllByUser(string username)
        {
            var user = BLLFactory.User().GetByUsername(username);
            return Orm.FilterAll(p => p.Author == user);
        }

        public List<Review> GetAllBySubject(string subjectName)
        {
            var subject = BLLFactory.Location().GetByName(subjectName);

            if (!(subject.Self is IReviewable))
                throw new Exception("The subject is not reviewable (not City or University)");

            return Orm.FilterAll(p => p.Subject == subject);
        }

        public Review GetByUserSubject(string username, string subjectName)
        {
            var user = BLLFactory.User().GetByUsername(username);
            var subject = BLLFactory.Location().GetByName(subjectName);

            if (!(subject.Self is IReviewable))
                throw new Exception("The subject is not reviewable (not City or University)");

            return Orm.FilterFirst(p => p.Author == user && p.Subject == subject);
        }

        public void Modify(string username, string subjectName, string comment, int rating)
        {
            var existingReview = GetByUserSubject(username, subjectName);
            if (existingReview == null)
                throw new Exception("No existing review for that user on that subject was found!");

            existingReview.Comment = comment;
            existingReview.Rating = rating;
            Orm.Update(existingReview);
        }

        public void Delete(Review review)
        {
            Orm.Delete(review);
        }

        public void Delete(string username, string subjectName)
        {
            var review = GetByUserSubject(username, subjectName);
            Delete(review);
        }

        //Added methods
        public List<Review> GetAllUniversitiesByUser(string username)
        {
            var user = BLLFactory.User().GetByUsername(username);
            List<Review> reviews = Orm.FilterAll(p => p.Author == user);
            return reviews.Where(review => review.Subject is University).ToList();
        }

        public List<Review> GetAllCitiesByUser(string username)
        {
            var user = BLLFactory.User().GetByUsername(username);
            List<Review> reviews = Orm.FilterAll(p => p.Author == user);
            return reviews.Where(review => review.Subject is City).ToList();
        }

        public List<Review> GetAllUniversityRatings()
        {
            return Orm.FilterAll(p => p.Subject is University).ToList();
        }

        public List<Review> GetAllCityRatings()
        {
            return Orm.FilterAll(p => p.Subject is City).ToList();
        }

    }
}
