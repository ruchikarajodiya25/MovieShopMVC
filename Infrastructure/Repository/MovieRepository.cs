using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {
            var movies = await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .ToListAsync();

            return movies;
        }

        public async Task<Movie?> GetMoviebyId(int id)
        {
            var movie = await _dbContext.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts)
                    .ThenInclude(mc => mc.Cast)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }

        public async Task<MovieDetailsModel?> GetMovieDetails(int id)
        {
            var movie = await _dbContext.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts)
                    .ThenInclude(mc => mc.Cast)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return null;
            }

            var movieDetails = new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Price = movie.Price,
                RunTime = movie.RunTime,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Genres = movie.MovieGenres.Select(mg => new GenreModel
                {
                    Id = mg.Genre.Id,
                    Name = mg.Genre.Name
                }).ToList(),
                Trailers = movie.Trailers.Select(t => new TrailerModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                }).ToList(),
                Casts = movie.MovieCasts.Select(mc => new CastModel
                {
                    Id = mc.Cast.Id,
                    Name = mc.Cast.Name,
                    Character = mc.Character,
                    ProfilePath = mc.Cast.ProfilePath
                }).ToList()
            };

            return movieDetails;
        }
    }
}
