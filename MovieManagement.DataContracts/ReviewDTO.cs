using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataContracts
{
    public class ReviewDTO
    {
        public int Score { get; set; }
        public Guid Id { get; set; }
    }
}
