using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class ReviewRepository : BaseRepository
    {
        public List<Review> SearchReviews()
        {
            return DbContext.Reviews.ToList();
        }

        public Review GetReview(Guid reviewId)
        {
            var review = DbContext.Reviews.FirstOrDefault(a => a.Id == reviewId);
            return review;
        }

        public void AddReview(Review newReview)
        {
            DbContext.Reviews.Add(newReview);
            DbContext.SaveChanges();
        }

        public void DeleteReview(Guid reviewId)
        {
            var review = DbContext.Reviews.FirstOrDefault(a => a.Id == reviewId);

            if (review != null)
            {
                DbContext.Reviews.Remove(review);
                DbContext.SaveChanges();
            }
        }

        public void UpdateReview(Review updatedReview)
        {
            var existingReview = DbContext.Reviews.FirstOrDefault(a => a.Id == updatedReview.Id);
            if (existingReview != null)
            {
                existingReview.Score = updatedReview.Score;
                DbContext.SaveChanges();
            }
        }
    }
}
