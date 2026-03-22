

namespace SGHSS.API.Domain.Entities

{
    public class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public Usuario() { }

        public Usuario(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha inválida");

            Email = email;
            Senha = senha;
        }
    }
}