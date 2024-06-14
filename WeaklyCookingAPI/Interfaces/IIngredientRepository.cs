using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByIdAsync(int id);
    }
}
