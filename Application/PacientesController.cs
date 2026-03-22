using Microsoft.AspNetCore.Mvc;
using EmpresaAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace EmpresaAPI.Application
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacientesServices _pacientesServices;

        public PacientesController(PacientesServices pacientesServices)
        {
            _pacientesServices = pacientesServices;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(string nome, int idade, string sexo, string cpf, string telefone)
        {
            try
            {
                await _pacientesServices.CadastrarPaciente(nome, idade, sexo, cpf, telefone);
                return StatusCode(201, "Paciente cadastrado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var pacientes = await _pacientesServices.ListarPacientes();
            return Ok(pacientes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, string nome, int idade, string sexo, string cpf, string telefone)
        {
            try
            {
                await _pacientesServices.AtualizarPaciente(id, nome, idade, sexo, cpf, telefone);
                return Ok("Paciente atualizado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _pacientesServices.RemoverPaciente(id);
                return Ok("Paciente removido com sucesso!");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}