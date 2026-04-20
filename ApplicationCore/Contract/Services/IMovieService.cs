using ApplicationCore.Models;

namespace ApplicationCore.Contract.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieCardModel>> GetHighestGrossingMovies();
        Task<MovieDetailsModel?> GetMovieDetails(int id);
    }
}