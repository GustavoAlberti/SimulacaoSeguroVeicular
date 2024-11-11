namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects
{
    public class Endereco
    {
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        // Construtor sem parâmetros para o EF Core
        private Endereco() { }

        public Endereco(string cep, string rua, string bairro, string cidade, string estado)
        {
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
