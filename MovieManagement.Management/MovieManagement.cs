using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class MovieManagement
    {
        private MovieRepository _repo = new MovieRepository();

        public List<MovieDTO> Search()
        {
            var result = _repo.SearchMovies();

            var toReturn = result.Select(a => new MovieDTO
            {
                Id = a.Id,
                AverageScore = (float)a.AverageScore,
                CategoryName = a.Category.Name,
                Length = a.Length,
                Rating = a.Rating,
                ReleaseDate = a.ReleaseDate,
                Title = a.Title
            }).ToList();
            return toReturn;
        }

        public MovieDTO GetMovie(Guid id)
        {
            var repoResult = _repo.GetMovie(id);
            return new MovieDTO
            {
                Id = repoResult.Id,
                AverageScore = (float)repoResult.AverageScore,
                CategoryName = repoResult.Category.Name,
                Length = repoResult.Length,
                Rating = repoResult.Rating,
                ReleaseDate = repoResult.ReleaseDate,
                Title = repoResult.Title
            };
        }
        
        public void DeleteMovie(Guid id)
        {
            _repo.DeleteMovie(id);
        }

        public void AddOrUpdate(MovieDTO movie)
        {
            var movy = new Movy
            {
                Id =movie.Id!=Guid.Empty ? movie.Id: Guid.NewGuid(),  //inline if
                Title = movie.Title,
                AverageScore = movie.AverageScore,
                Length = movie.Length,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
            };

            //category is a bit tricky
            //if we have something in our MovieDTO model ( movie ), then we need to search for the category with that name and get its Id in order to assign it to our movie
            //so let's define a search by name in category
            if (!string.IsNullOrEmpty(movie.CategoryName))
            {
                var categoryRepo = new CategoryRepository();
                var existingCategory = categoryRepo.GetCategoryByName(movie.CategoryName);
                if (existingCategory != null)
                {
                    movy.CategoryId = existingCategory.Id;
                }
            }

            if (movie.Id != Guid.Empty) //movie exists => update
            {
               _repo.UpdateMovie(movy);
            }
            else //movie doesn't exist => add
            {
                _repo.AddMovie(movy);
            }
        }


    }
}
