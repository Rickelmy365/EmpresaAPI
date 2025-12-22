using EmpresaAPI.Domain.Entites;

namespace EmpresaAPI.Domain.Interfaces
{
    //Interface do repositório para gerenciar os dados dos funcionários
    public interface IFuncionariosRepository
    {
        Task AddAsync(Funcionarios funcionario);
        Task<IEnumerable<Funcionarios>> GetAllAsync();
        Task<Funcionarios?> GetByIdAsync(int id);
        Task UpdateAsync(Funcionarios funcionario);
        Task DeleteAsync(Funcionarios funcionario);
    }
}
