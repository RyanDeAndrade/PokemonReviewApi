using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review>GetReview()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviews()
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
