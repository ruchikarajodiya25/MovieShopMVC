using ApplicationCore.Models;

namespace ApplicationCore.Contract.Services
{
    public interface ICastService
    {
        Task<CastDetailsModel?> GetCastDetails(int id);
    }
}
