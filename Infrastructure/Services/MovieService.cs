using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieCardModel>> GetHighestGrossingMovies()
        {
            var movies = await _movieRepository.GetHighestGrossingMovies();

            var response = movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl,
                Rating = m.Rating
            });

            return response;
        }

        public async Task<MovieDetailsModel?> GetMovieDetails(int id)
        {
            return await _movieRepository.GetMovieDetails(id);
        }
    }
}
