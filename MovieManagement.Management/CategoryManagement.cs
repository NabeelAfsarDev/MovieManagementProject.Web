using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class CategoryManagement
    {
        private CategoryRepository _repo = new CategoryRepository();

        public List<CategoryDTO> Search()
        {
            var result = _repo.SearchCategories();
            return result.Select(a => new CategoryDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
        }

        public CategoryDTO GetCategory(Guid id)
        {
            var repoResult = _repo.GetCategory(id);
            return new CategoryDTO
            {
                Id = repoResult.Id,
                Name = repoResult.Name
            };
        }
        
        public void DeleteCategory(Guid id)
        {
            _repo.DeleteCategory(id);
        }

        public void AddOrUpdate(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id!=Guid.Empty ? categoryDTO.Id: Guid.NewGuid(),  
                Name = categoryDTO.Name,
            };

            if (categoryDTO.Id != Guid.Empty) 
            {
               _repo.UpdateCategory(category);
            }
            else
            {
                _repo.AddCategory(category);
            }
        }


    }
}
