using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        private MovieManagement.Management.ReviewManagement _management = new MovieManagement.Management.ReviewManagement();

        [HttpGet]
        [Route("Search")]
        public List<ReviewDTO> Search()
        {
            return _management.Search();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _management.DeleteReview(id);
        }

        [HttpGet]
        [Route("{id}")]
        public ReviewDTO GetReview(Guid id)
        {
            return _management.GetReview(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateReview([FromBody]ReviewDTO review, Guid id)
        {
            review.Id = id;
            _management.AddOrUpdate(review);
        }

        [HttpPost]
        [Route("")]
        public void Save([FromBody]ReviewDTO review)
        {
            _management.AddOrUpdate(review);
        }
    }
}
