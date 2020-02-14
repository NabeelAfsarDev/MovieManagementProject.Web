using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    public class BaseRepository
    {
        protected MoviesDBEntities DbContext = new MoviesDBEntities();
    }
}
