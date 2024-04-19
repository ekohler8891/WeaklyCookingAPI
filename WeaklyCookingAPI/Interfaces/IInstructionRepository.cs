using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Interfaces
{
    public interface IInstructionRepository
    {
        Task<List<Instruction>> GetAllAsync();
        Task<Instruction> GetByIdAsync(int id);
    }
}
