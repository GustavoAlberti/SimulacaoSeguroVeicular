namespace SimulacaoSeguroVeicular.Domain.Simulacoes.Services
{
    public class FakeConsultarHistoricoAcidentesService
    {
        public Task<int> ConsultarHistoricoAcidentesAsync(string cpfcondutor)
        {
            // Simula o numero de acidentes nos ultimos 3 anos.
            var random = new Random();
            int acidentes = random.Next(0,4);
            //ver para retornar um json
            return Task.FromResult(acidentes);
        }
    }
}
