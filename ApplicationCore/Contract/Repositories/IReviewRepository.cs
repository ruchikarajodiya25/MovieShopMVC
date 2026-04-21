using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review?> GetReviewByIdAsync(int id);
        Task<int> CreateReviewAsync(Review review);
        Task<int> UpdateReviewAsync(Review review);
        Task<int> DeleteReviewAsync(int id);
    }
}
