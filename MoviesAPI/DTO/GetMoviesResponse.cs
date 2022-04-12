using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTO
{
    public class GetMoviesResponse
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
        public Producers Producers { get; set; }
        public ICollection<Actors> Actors { get; set; }
        public string error { get; set; }
    }
}
