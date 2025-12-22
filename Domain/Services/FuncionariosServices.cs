using EmpresaAPI.Domain.Interfaces;
using EmpresaAPI.Domain.Entites;

namespace EmpresaAPI.Domain.Services
{
    public class FuncionariosServices
    {
        //Injeção de dependência do repositório e funções para o controller
        private readonly IFuncionariosRepository _repository;
        
        //CONSTRUTOR
        public FuncionariosServices(IFuncionariosRepository repository)
        {
            _repository = repository;
        }

        //Regra de negócio para o serviço de funcionários
        public async Task CadastrarFuncionario(string nome, string cargo, int Salario)
        {
            var funcionario = new Funcionarios(nome, cargo, Salario);
            await _repository.AddAsync(funcionario);
        }

        //Retorna a lista de funcionários

    public async Task<IEnumerable<Funcionarios>> ListarFuncionarios()
        {
            return await _repository.GetAllAsync();
        }
    

    //Retorna a lista de funcionários cadastrados
    public async Task AtualizarFuncionario(int id, string nome, string cargo, int salario)
    {
        var funcionarioExistente = await _repository.GetByIdAsync(id);
        if (funcionarioExistente == null)
        {
            throw new ArgumentException("Funcionário não encontrado.");
        }

        funcionarioExistente.Nome = nome;
        funcionarioExistente.Cargo = cargo;
        funcionarioExistente.Salario = salario;

        await _repository.UpdateAsync(funcionarioExistente);
    }
    //DELETE
    public async Task RemoverFuncionario(int id)
    {
            var funcionario = await _repository.GetByIdAsync(id);
            if (funcionario == null)
            {
                throw new ArgumentException("Funcionário não encontrado.");
            }
            await _repository.DeleteAsync(funcionario);
    }
    }
}