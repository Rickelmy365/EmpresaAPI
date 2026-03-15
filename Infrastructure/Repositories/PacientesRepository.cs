using EmpresaAPI.Domain.Interfaces;
using EmpresaAPI.Domain.Entites;
using EmpresaAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Infrastructure
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly AppDbContext _context;

        public PacientesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pacientes paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pacientes>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Pacientes?> GetByIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task UpdateAsync(Pacientes paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pacientes paciente)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
