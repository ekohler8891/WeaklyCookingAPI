using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Interfaces;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Repository
{
    public class InstructionRepository : IInstructionRepository
    {
        private readonly ApplicationDBContext _context;
        public InstructionRepository(ApplicationDBContext context)
        {
            _context = context;           
        }
        public async Task<List<Instruction>> GetAllAsync()
        {
            return await _context.Instructions.ToListAsync();
        }

        public async Task<Instruction> GetByIdAsync(int id)
        {
            return await _context.Instructions.FindAsync(id);
        }
    }
}
