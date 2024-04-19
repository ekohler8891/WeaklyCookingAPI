using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllAsync();

    }
}
