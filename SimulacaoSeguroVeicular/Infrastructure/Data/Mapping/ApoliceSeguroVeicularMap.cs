using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulacaoSeguroVeicular.Domain.Simulacoes;

namespace SimulacaoSeguroVeicular.Infrastructure.Data.Mapping
{
    public class ApoliceSeguroVeicularMap : IEntityTypeConfiguration<Apolice>
    {
        public void Configure(EntityTypeBuilder<Apolice> builder)
        {
            builder.ToTable("APOLICES");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CotacaoId)
                .IsRequired();

            builder.Property(a => a.MarcaVeiculo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.ModeloVeiculo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.AnoVeiculo)
                .IsRequired();

            builder.Property(a => a.NomeProprietario)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.CpfProprietario)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(a => a.NomeCondutor)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.CpfCondutor)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(a => a.TipoCobertura)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.ValorSeguroTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(a => a.DataEmissao)
                .IsRequired();

            builder.Property(a => a.DataVigencia)
                .IsRequired();
        }
    }
}