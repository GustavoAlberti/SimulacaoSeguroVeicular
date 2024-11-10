using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulacaoSeguroVeicular.Dominio.Simulacoes;

namespace SimulacaoSeguroVeicular.Infrastructure.Data.Mapping
{
    public class CotacaoSeguroVeicularMap : IEntityTypeConfiguration<CotacaoSeguroVeicular>
    {
        public void Configure(EntityTypeBuilder<CotacaoSeguroVeicular> builder)
        {
            builder.ToTable("COTACOES");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValorMercadoFipe)
                .IsRequired(false)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ValorSeguroTotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.NivelDeRisco)
                .IsRequired(false);

            builder.Property(x => x.Status)
                .HasDefaultValue(SeguroVeicularStatus.Pendente)
                .IsRequired();

            builder.Property(x => x.DataAprovacao)
                .IsRequired(false);

            builder.OwnsOne(x => x.Veiculo, veiculo =>
            {
                veiculo.WithOwner();
                veiculo.Property(v => v.Marca).HasColumnName("VeiculoMarca").HasColumnType("varchar(100)").IsRequired();
                veiculo.Property(v => v.Modelo).HasColumnName("VeiculoModelo").HasColumnType("varchar(100)").IsRequired();
                veiculo.Property(v => v.Ano).HasColumnName("VeiculoAno").IsRequired();
            });


            builder.OwnsOne(x => x.Proprietario, proprietario =>
            {
                proprietario.Property(p => p.Cpf).HasColumnName("ProprietarioCpf").HasMaxLength(11).IsRequired();
                proprietario.Property(p => p.Nome).HasColumnName("ProprietarioNome").HasMaxLength(100).IsRequired();
                proprietario.Property(p => p.DataNascimento).HasColumnName("ProprietarioDataNascimento").IsRequired();

                proprietario.OwnsOne(p => p.Residencial, residencial =>
                {
                    residencial.Property(e => e.Cep).HasColumnName("ProprietarioCep").HasMaxLength(8).IsRequired();
                    residencial.Property(e => e.Rua).HasColumnName("ProprietarioRua").HasMaxLength(100).IsRequired();
                    residencial.Property(e => e.Bairro).HasColumnName("ProprietarioBairro").HasMaxLength(50).IsRequired();
                    residencial.Property(e => e.Cidade).HasColumnName("ProprietarioCidade").HasMaxLength(50).IsRequired();
                    residencial.Property(e => e.Estado).HasColumnName("ProprietarioEstado").HasMaxLength(2).IsRequired();
                });
            });

            builder.OwnsOne(x => x.Condutor, condutor =>
            {
                condutor.Property(c => c.Cpf).HasColumnName("CondutorCpf").HasMaxLength(11).IsRequired();
                condutor.Property(c => c.Nome).HasColumnName("CondutorNome").HasMaxLength(100).IsRequired();
                condutor.Property(c => c.DataNascimento).HasColumnName("CondutorDataNascimento").IsRequired();

                condutor.OwnsOne(c => c.Residencial, residencial =>
                {
                    residencial.Property(c => c.Cep).HasColumnName("ProponenteCep").HasColumnType("varchar(15)").IsRequired();
                    residencial.Property(c => c.Rua).HasColumnName("ProponenteRua").HasColumnType("varchar(100)").IsRequired();
                    residencial.Property(c => c.Bairro).HasColumnName("ProponenteBairro").HasColumnType("varchar(50)").IsRequired();
                    residencial.Property(c => c.Cidade).HasColumnName("ProponenteCidade").HasColumnType("varchar(150)").IsRequired();
                    residencial.Property(c => c.Estado).HasColumnName("ProponenteEstado").HasColumnType("varchar(2)").IsRequired();
                });
            });

            builder.Property(x => x.CoberturaSelecionada)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}