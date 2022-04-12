using System;
using System.Collections.Generic;

namespace MoviesAPI.Models
{
    public partial class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int ProducerId { get; set; }
    }
}
