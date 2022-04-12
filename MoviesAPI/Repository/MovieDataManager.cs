using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Models.Repository.DataManager
{
    public class MovieDataManager : IDataRepository
    {
        private MoviesDBContext _moviesDBContext;

        public MovieDataManager()
        {
            _moviesDBContext = new MoviesDBContext();
        }

        public AddMovieResponse AddMovie(MoviesAPI.DTO.GetMoviesResponse movie)
        {
            var addMovieResponse = new AddMovieResponse();
            try
            {
                if (movie != null)
                {
                    Movies newMovie = new Movies();
                    newMovie.MovieName = movie.MovieName;
                    newMovie.DateOfRelease = movie.DateOfRelease;
                    newMovie.ProducerId = movie.Producers.ProducerId;
                    var x = _moviesDBContext.Movies.Add(newMovie);
                    _moviesDBContext.SaveChanges();

                    foreach (var actor in movie.Actors)
                    {
                        MovieCasting newCasting = new MovieCasting();
                        newCasting.ActorId = actor.ActorId;
                        newCasting.MovieId = newMovie.MovieId;
                        _moviesDBContext.MovieCasting.Add(newCasting);
                        _moviesDBContext.SaveChanges();
                    }
                }
                addMovieResponse.success = true;
            }
            
            catch (Exception ex)
            {
                addMovieResponse.success = false;
                addMovieResponse.error = ex.InnerException.Message;
            }

            return addMovieResponse;
        }

        public IEnumerable<MoviesAPI.DTO.GetMoviesResponse> GetMovies()
        {
            var movieData = new List<MoviesAPI.DTO.GetMoviesResponse>();
            try
            {
                var movies = _moviesDBContext.Movies.ToList();
                if (movies != null)
                {
                    List<Actors> actorsData = new List<Actors>();
                    var actors = _moviesDBContext.Actors.ToList();
                    if (actors != null)
                    {
                        foreach (var movie in movies)
                        {
                            var movieInfo = new MoviesAPI.DTO.GetMoviesResponse
                            {
                                MovieId = movie.MovieId,
                                MovieName = movie.MovieName,
                                DateOfRelease = movie.DateOfRelease
                            };
                            var actorList = new List<Actors>();
                            var movieCasting = _moviesDBContext.MovieCasting.Where(m => m.MovieId == movie.MovieId).ToList();
                            foreach (var mc in movieCasting)
                            {
                                var a = _moviesDBContext.Actors.Where(y => y.ActorId == mc.ActorId).ToList();
                                actorList.AddRange(a);
                                ;
                            }
                            movieInfo.Actors = actorList;

                            var producer = _moviesDBContext.Producers.Where(m => m.ProducerId == movie.ProducerId).ToList();
                            movieInfo.Producers = producer.FirstOrDefault();
                            movieData.Add(movieInfo);
                        }
                    }
                }
            }            
            catch(Exception ex)
            {
                throw ex;
            }
           
            return movieData;
        }

        public UpdateMovieResponse UpdateMovie(int id, MoviesAPI.DTO.GetMoviesResponse movieToUpdate)
        {
            var updateMovieResponse = new UpdateMovieResponse();
            try
            {
                var movie = _moviesDBContext.Movies.Where(x => x.MovieId == id).ToList().FirstOrDefault();
                if (movie != null && movieToUpdate != null)
                {
                    List<int> updatedActors = new List<int>();
                    List<int> existingActors = new List<int>();

                    movie.MovieName = movieToUpdate.MovieName;
                    movie.DateOfRelease = movieToUpdate.DateOfRelease;
                    movie.ProducerId = movieToUpdate.Producers.ProducerId;
                    _moviesDBContext.Movies.Update(movie);

                    var movieCasts = _moviesDBContext.MovieCasting.Where(x => x.MovieId == id).ToList();
                    if (movieCasts != null)
                    {
                        foreach (var actor in movieToUpdate.Actors)
                        {
                            updatedActors.Add(actor.ActorId);
                        }

                        foreach (var actor in movieCasts)
                        {
                            existingActors.Add(actor.ActorId);
                        }

                        var addActors = updatedActors.Except(existingActors).ToList();
                        var removeActors = existingActors.Except(updatedActors).ToList();

                        removeActors.ForEach(actorToDelete =>
                            _moviesDBContext.MovieCasting.Remove(
                            _moviesDBContext.MovieCasting.First(
                                x => x.ActorId == actorToDelete & x.MovieId == id)));

                        foreach (var actor in addActors)
                        {
                            MovieCasting newCasting = new MovieCasting();
                            newCasting.ActorId = actor;
                            newCasting.MovieId = id;
                            _moviesDBContext.MovieCasting.Add(newCasting);
                        }

                        _moviesDBContext.SaveChanges();
                    }
                }
                updateMovieResponse.success = true;                
            }
  
            catch(Exception ex)
            {
                updateMovieResponse.success = false;
                updateMovieResponse.error = ex.InnerException.Message;
            }
            return updateMovieResponse;
        }
    }
}
