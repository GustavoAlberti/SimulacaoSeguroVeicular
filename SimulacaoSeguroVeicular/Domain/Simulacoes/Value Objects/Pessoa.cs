namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects
{
    public class Pessoa
    {
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Residencial { get; private set; }

        private Pessoa() { }

        public Pessoa(string cpf, string nome, DateTime dataNascimento, Endereco residencial)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Residencial = residencial;
        }
    }
}
