using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class ReviewManagement
    {
        private ReviewRepository _repo = new ReviewRepository();

        public List<ReviewDTO> Search()
        {
            var result = _repo.SearchReviews();
            return result.Select(a => new ReviewDTO
            {
                Id = a.Id,
                Score = a.Score
            }).ToList();
        }

        public ReviewDTO GetReview(Guid id)
        {
            var repoResult = _repo.GetReview(id);
            return new ReviewDTO
            {
                Id = repoResult.Id,
                Score = repoResult.Score
            };
        }
        
        public void DeleteReview(Guid id)
        {
            _repo.DeleteReview(id);
        }

        public void AddOrUpdate(ReviewDTO reviewDTO)
        {
            var review = new Review
            {
                Id = reviewDTO.Id!=Guid.Empty ? reviewDTO.Id: Guid.NewGuid(),  
                Score = reviewDTO.Score,
            };

            if (reviewDTO.Id != Guid.Empty) 
            {
               _repo.UpdateReview(review);
            }
            else
            {
                _repo.AddReview(review);
            }
        }


    }
}
