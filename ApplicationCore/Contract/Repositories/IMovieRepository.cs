using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contract.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetHighestGrossingMovies();
        Task<Movie?> GetMoviebyId(int id);
        Task<MovieDetailsModel?> GetMovieDetails(int id);
    }
}
