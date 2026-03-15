using EmpresaAPI.Domain.Entites;

namespace EmpresaAPI.Domain.Interfaces
{
    public interface IPacientesRepository
    {
        Task AddAsync(Pacientes paciente);
        Task<IEnumerable<Pacientes>> GetAllAsync();
        Task<Pacientes?> GetByIdAsync(int id);
        Task UpdateAsync(Pacientes paciente);
        Task DeleteAsync(Pacientes paciente);
    }
}