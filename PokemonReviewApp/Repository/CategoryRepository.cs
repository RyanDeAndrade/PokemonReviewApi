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
        public bool CreateCategory(Category category)
        {
            //change tracker
            //add,updating, modifying
            // conntected vs disconnect
            // EntityState.Added
            //
            _context.Add(category);
            return Save();     
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
