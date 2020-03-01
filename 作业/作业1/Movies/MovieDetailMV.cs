using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class MovieDetailMV
    {
        public int Id { get; set; }
        public int AdressId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Company { get; set; }
        public string AdressName { get; set; }
        public string OccupationName { get; set; }
    }
}
