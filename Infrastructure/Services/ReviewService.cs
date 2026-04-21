using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET ALL REVIEWS
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviewsAsync();
        }

        // GET REVIEW BY ID
        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetReviewByIdAsync(id);
        }

        // CREATE REVIEW
        public async Task<int> CreateReviewAsync(Review review)
        {
            if (review.Rating < 1 || review.Rating > 5)
            {
                throw new Exception("Rating must be between 1 and 5");
            }

            review.CreatedDate = DateTime.Now;
            return await _reviewRepository.CreateReviewAsync(review);
        }

        // UPDATE REVIEW
        public async Task<int> UpdateReviewAsync(Review review)
        {
            var existing = await _reviewRepository.GetReviewByIdAsync(review.Id);

            if (existing == null)
            {
                throw new Exception("Review not found");
            }

            review.UpdatedDate = DateTime.Now;
            return await _reviewRepository.UpdateReviewAsync(review);
        }

        // DELETE REVIEW
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var existing = await _reviewRepository.GetReviewByIdAsync(id);

            if (existing == null)
            {
                return false;
            }

            var rows = await _reviewRepository.DeleteReviewAsync(id);
            return rows > 0;
        }
    }
}