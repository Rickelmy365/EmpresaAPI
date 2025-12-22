namespace EmpresaAPI.Domain.Entites
{
    public class Funcionarios
    {
        //PROPRIEDADES que represeta um funcionário da empresa
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public int Salario { get; set; }

        //CONSTRUTOR
        
        protected Funcionarios() { }

        public Funcionarios(string? nome, string? cargo, int salario)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da pessoa não pode ser vazio.");
            if(string.IsNullOrWhiteSpace(cargo))
                throw new ArgumentException("Cargo da pessoa não pode ser vazio.");
            if(salario <= 0)
                throw new ArgumentException("Salário deve ser maior que zero.");
            Nome = nome;
            Cargo = cargo;
            Salario = salario;
        }
    }
}