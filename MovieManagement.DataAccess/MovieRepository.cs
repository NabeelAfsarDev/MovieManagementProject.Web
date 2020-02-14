using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class MovieRepository : BaseRepository
    {
        public List<Movy> SearchMovies()
        {
            return DbContext.Movies.ToList();
        }

        public Movy GetMovie(Guid movieId)
        {
            var movie = DbContext.Movies.FirstOrDefault(a => a.Id == movieId);
            return movie;
        }

        public void AddMovie(Movy newMovie)
        {
            DbContext.Movies.Add(newMovie);
            DbContext.SaveChanges();
        }

        public void DeleteMovie(Guid movieId)
        {
            var movie = DbContext.Movies.FirstOrDefault(a => a.Id == movieId);

            if (movie != null)
            {
                DbContext.Movies.Remove(movie);
                DbContext.SaveChanges();
            }
        }

        public void UpdateMovie(Movy updatedMovie)
        {
            var existingMovie = DbContext.Movies.FirstOrDefault(a => a.Id == updatedMovie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = updatedMovie.Title;
                existingMovie.Rating = updatedMovie.Rating;
                DbContext.SaveChanges();
            }
        }
    }
}
