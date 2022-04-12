using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTO;
using MoviesAPI.Models;
using MoviesAPI.Models.Repository;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public MoviesController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET api/movies
        [HttpGet]
        public IEnumerable<MoviesAPI.DTO.GetMoviesResponse> GetMovies()
        {
            var movies = _dataRepository.GetMovies();
            return movies;
        }

        // POST api/movies
        [HttpPost]
        public AddMovieResponse Post([FromBody] MoviesAPI.DTO.GetMoviesResponse movie)
        {
            var addMovieResponse = new AddMovieResponse();
            if(movie != null)
            {
                addMovieResponse = _dataRepository.AddMovie(movie);
            }            
            return addMovieResponse;
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public UpdateMovieResponse Put(int id, [FromBody] MoviesAPI.DTO.GetMoviesResponse movie)
        {
            var updateMovieResponse = new UpdateMovieResponse();
            if(movie != null)
            { 
                updateMovieResponse = _dataRepository.UpdateMovie(id, movie);
            }
            return updateMovieResponse;
        }
    }
}
