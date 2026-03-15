namespace EmpresaAPI.Domain.Entites
{
    public class Pacientes
    {
        // PROPRIEDADES do paciente
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Sexo { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }

        protected Pacientes() { }

        public Pacientes(string nome, int idade, string sexo, string cpf, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do paciente não pode ser vazio.");

            if (idade <= 0)
                throw new ArgumentException("Idade inválida.");

            if (string.IsNullOrWhiteSpace(sexo))
                throw new ArgumentException("Sexo não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("CPF não pode ser vazio.");

            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            CPF = cpf;
            Telefone = telefone;
        }
    }
}