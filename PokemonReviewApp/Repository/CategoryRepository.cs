using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using SQLitePCL;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;   
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int Id)
        {
           return _context.Categories.Any(c => c.Id == Id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();    
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int CategoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == CategoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
