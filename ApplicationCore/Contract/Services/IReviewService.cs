using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review?> GetReviewByIdAsync(int id);
        Task<int> CreateReviewAsync(Review review);
        Task<int> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
