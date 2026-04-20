using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast?> GetById(int id)
        {
            var cast = await _dbContext.Casts
                .Include(c => c.MovieCasts)
                    .ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cast;
        }

        public async Task<CastDetailsModel?> GetCastDetails(int id)
        {
            var cast = await _dbContext.Casts
                .Include(c => c.MovieCasts)
                    .ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cast == null)
            {
                return null;
            }

            var castDetails = new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
                Movies = cast.MovieCasts.Select(mc => new MovieCardModel
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    PosterUrl = mc.Movie.PosterUrl,
                    Rating = mc.Movie.Rating
                }).ToList()
            };

            return castDetails;
        }
    }
}