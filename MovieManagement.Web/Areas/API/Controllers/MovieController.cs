using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private MovieManagement.Management.MovieManagement _management = new MovieManagement.Management.MovieManagement();

        [HttpGet]
        [Route("Search")]
        public List<MovieDTO> Search()
        {
            return _management.Search();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _management.DeleteMovie(id);
        }

        [HttpGet]
        [Route("{id}")]
        public MovieDTO GetMovie(Guid id)
        {
            return _management.GetMovie(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateMovie([FromBody]MovieDTO movie, Guid id)
        {
            movie.Id = id;
            _management.AddOrUpdate(movie);
        }

        [HttpPost]
        [Route("")]
        public void SaveMovie([FromBody]MovieDTO movie)
        {
            _management.AddOrUpdate(movie);
        }
    }
}
