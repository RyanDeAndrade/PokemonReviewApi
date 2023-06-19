using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int CategoryId);
        bool CategoryExists(int Id);
        bool CreateCategory(Category category);
        bool Save();

    }
}
