using EmpresaAPI.Infrastructure.Data;
using EmpresaAPI.Domain.Entites;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SGHSS.API.Domain.Entities;
using Microsoft.Extensions.Configuration; // Adicione este using

namespace EmpresaAPI.Domain.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; // Adicionado para ler o appsettings

        // Atualize o construtor para receber o IConfiguration
        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Registrar(string email, string senha)
        {
            var usuario = new Usuario(email, senha);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public string Login(string email, string senha)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
                throw new ArgumentException("Usuário ou senha inválidos");

            var tokenHandler = new JwtSecurityTokenHandler();
            
            // BUSCA A CHAVE LONGA DO APPSETTINGS
            var secretKey = _configuration["Jwt:Key"] ?? "Uma_Chave_Reserva_Com_Mais_De_32_Caracteres_Aqui"; 
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("id", usuario.Id.ToString()) // Dica: é bom ter o ID no token
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                // Adicionando Issuer e Audience para bater com o Program.cs
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}