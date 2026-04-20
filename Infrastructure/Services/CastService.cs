using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel?> GetCastDetails(int id)
        {
            return await _castRepository.GetCastDetails(id);
        }
    }
}
