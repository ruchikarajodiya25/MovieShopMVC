using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contract.Repositories
{
    public interface ICastRepository : IRepository<Cast>
    {
        Task<CastDetailsModel?> GetCastDetails(int id);
    }
}