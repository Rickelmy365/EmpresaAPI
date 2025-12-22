using EmpresaAPI.Domain.Interfaces;
using EmpresaAPI.Domain.Entites;
using EmpresaAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Infrastructure
{
    //Implementação do repositório para gerenciar os dados dos funcionários no banco de dados
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private readonly AppDbContext _context;

        //Recebe o DbContext via injeção de dependência
        public FuncionariosRepository(AppDbContext context)
        {
            _context = context;
        }
        
        //Adiciona um novo funcionário ao banco de dados
        public async Task AddAsync(Funcionarios funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Funcionarios>> GetAllAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionarios?> GetByIdAsync(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task UpdateAsync(Funcionarios funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Funcionarios funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}
