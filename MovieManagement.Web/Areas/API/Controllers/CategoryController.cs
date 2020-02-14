using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private MovieManagement.Management.CategoryManagement _management = new MovieManagement.Management.CategoryManagement();

        [HttpGet]
        [Route("Search")]
        public List<CategoryDTO> Search()
        {
            return _management.Search();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _management.DeleteCategory(id);
        }

        [HttpGet]
        [Route("{id}")]
        public CategoryDTO GetCategory(Guid id)
        {
            return _management.GetCategory(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateCategory([FromBody]CategoryDTO category, Guid id)
        {
            category.Id = id;
            _management.AddOrUpdate(category);
        }

        [HttpPost]
        [Route("")]
        public void Save([FromBody]CategoryDTO category)
        {
            _management.AddOrUpdate(category);
        }
    }
}
