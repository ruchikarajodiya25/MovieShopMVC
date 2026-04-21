using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DapperContext _context;

        public ReviewRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            var sql = @"SELECT Id, MovieId, UserId, Rating, ReviewText, CreatedDate, UpdatedDate
                        FROM Review
                        ORDER BY Id DESC";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Review>(sql);
        }

        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            var sql = @"SELECT Id, MovieId, UserId, Rating, ReviewText, CreatedDate, UpdatedDate
                        FROM Review
                        WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Review>(sql, new { Id = id });
        }

        public async Task<int> CreateReviewAsync(Review review)
        {
            var sql = @"
                INSERT INTO Review (MovieId, UserId, Rating, ReviewText, CreatedDate)
                VALUES (@MovieId, @UserId, @Rating, @ReviewText, @CreatedDate);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, review);
        }

        public async Task<int> UpdateReviewAsync(Review review)
        {
            var sql = @"
                UPDATE Review
                SET MovieId = @MovieId,
                    UserId = @UserId,
                    Rating = @Rating,
                    ReviewText = @ReviewText,
                    UpdatedDate = @UpdatedDate
                WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, review);
        }

        public async Task<int> DeleteReviewAsync(int id)
        {
            var sql = @"DELETE FROM Review WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
