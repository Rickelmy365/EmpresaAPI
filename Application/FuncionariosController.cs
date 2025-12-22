using Microsoft.AspNetCore.Mvc;
using EmpresaAPI.Domain.Services;

namespace EmpresaAPI.Application
// Controller responsável por gerenciar as requisições
// relacionadas aos funcionários da empresa
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        
        private readonly FuncionariosServices _funcionariosServices;

        //Injeção de dependência do serviço de funcionários
        public FuncionariosController(FuncionariosServices funcionariosServices)
        {
            _funcionariosServices = funcionariosServices;
        }

        //POST para cadastrar um novo funcionário
        [HttpPost("Cadastra um novo funcionário")]
        public async Task<IActionResult> Cadastrar(string nome, string cargo, int salario)
        {
            try
            {
                await _funcionariosServices.CadastrarFuncionario(nome, cargo, salario);
                return StatusCode(201, "Funcionário cadastrado com sucesso!!!!");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        //GET para listar todos os funcionários
        [HttpGet("Lista todos os funcionários")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var funcionarios = await _funcionariosServices.ListarFuncionarios();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        //PUT para atualizar um funcionário existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, string nome, string cargo, int salario)
        {
            try
            {
                await _funcionariosServices.AtualizarFuncionario(id, nome, cargo, salario);
                return StatusCode(200, "Funcionário atualizado com sucesso!!!!");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        //DELETE para remover um funcionário existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _funcionariosServices.RemoverFuncionario(id);
                return StatusCode(200, "Funcionário removido com sucesso!!!!");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        
    }
}