namespace ApplicationCore.Models
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public decimal? Rating { get; set; }
        public decimal? Price { get; set; }
        public int? RunTime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Revenue { get; set; }

        public List<GenreModel> Genres { get; set; } = new();
        public List<TrailerModel> Trailers { get; set; } = new();
        public List<CastModel> Casts { get; set; } = new();
    }
}
