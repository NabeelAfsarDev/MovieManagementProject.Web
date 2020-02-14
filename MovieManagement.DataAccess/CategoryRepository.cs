using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class CategoryRepository : BaseRepository
    {
        public List<Category> SearchCategories()
        {
            return DbContext.Categories.ToList();
        }

        public Category GetCategory(Guid categoryId)
        {
            var category = DbContext.Categories.FirstOrDefault(a => a.Id == categoryId);
            return category;
        }
        
        public Category GetCategoryByName(string name)
        {
            //we called ToLower, which transforms the string into lowercase, because we want strings like Drama, dRama, dRaMa to match
            var lowerCaseName = name.ToLower();
            var category = DbContext.Categories.FirstOrDefault(a => a.Name.ToLower().Contains(lowerCaseName));
            return category;
        }

        public void AddCategory(Category newCategory)
        {
            DbContext.Categories.Add(newCategory);
            DbContext.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            var category = DbContext.Categories.FirstOrDefault(a => a.Id == categoryId);

            if (category != null)
            {
                DbContext.Categories.Remove(category);
                DbContext.SaveChanges();
            }
        }

        public void UpdateCategory(Category updatedCategory)
        {
            var existingCategory = DbContext.Categories.FirstOrDefault(a => a.Id == updatedCategory.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                DbContext.SaveChanges();
            }
        }
    }
}
