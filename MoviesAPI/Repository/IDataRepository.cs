using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.DTO;

namespace MoviesAPI.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<MoviesAPI.DTO.GetMoviesResponse> GetMovies();
        AddMovieResponse AddMovie(MoviesAPI.DTO.GetMoviesResponse movie);
        UpdateMovieResponse UpdateMovie(int id, MoviesAPI.DTO.GetMoviesResponse movieToUpdate);
    }
}
