using EmpresaAPI.Domain.Interfaces;
using EmpresaAPI.Domain.Entites;


namespace EmpresaAPI.Domain.Services
{
    public class PacientesServices
    {
        private readonly IPacientesRepository _repository;

        public PacientesServices(IPacientesRepository repository)
        {
            _repository = repository;
        }

        public async Task CadastrarPaciente(string nome, int idade, string sexo, string cpf, string telefone)
        {
            var paciente = new Pacientes(nome, idade, sexo, cpf, telefone);
            await _repository.AddAsync(paciente);
        }

        public async Task<IEnumerable<Pacientes>> ListarPacientes()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AtualizarPaciente(int id, string nome, int idade, string sexo, string cpf, string telefone)
        {
            var pacienteExistente = await _repository.GetByIdAsync(id);

            if (pacienteExistente == null)
                throw new ArgumentException("Paciente não encontrado.");

            pacienteExistente.Nome = nome;
            pacienteExistente.Idade = idade;
            pacienteExistente.Sexo = sexo;
            pacienteExistente.CPF = cpf;
            pacienteExistente.Telefone = telefone;

            await _repository.UpdateAsync(pacienteExistente);
        }

        public async Task RemoverPaciente(int id)
        {
            var paciente = await _repository.GetByIdAsync(id);

            if (paciente == null)
                throw new ArgumentException("Paciente não encontrado.");

            await _repository.DeleteAsync(paciente);
        }
    }
}