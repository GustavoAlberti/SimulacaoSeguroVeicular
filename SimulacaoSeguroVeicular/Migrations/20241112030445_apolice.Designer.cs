﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimulacaoSeguroVeicular.Infrastructure.Data;

#nullable disable

namespace SimulacaoSeguroVeicular.Migrations
{
    [DbContext(typeof(CotacaoDbContext))]
    [Migration("20241112030445_apolice")]
    partial class apolice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimulacaoSeguroVeicular.Domain.Simulacoes.Apolice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoVeiculo")
                        .HasColumnType("int");

                    b.Property<int>("CotacaoId")
                        .HasColumnType("int");

                    b.Property<string>("CpfCondutor")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CpfProprietario")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVigencia")
                        .HasColumnType("datetime2");

                    b.Property<string>("MarcaVeiculo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModeloVeiculo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeCondutor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeProprietario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TipoCobertura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ValorSeguroTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("APOLICES", (string)null);
                });

            modelBuilder.Entity("SimulacaoSeguroVeicular.Dominio.Simulacoes.CotacaoSeguroVeicular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoberturaSelecionada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAprovacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NivelDeRisco")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroDeAcidentes")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal?>("ValorMercadoFipe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorSeguroTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("COTACOES", (string)null);
                });

            modelBuilder.Entity("SimulacaoSeguroVeicular.Dominio.Simulacoes.CotacaoSeguroVeicular", b =>
                {
                    b.OwnsOne("SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects.Pessoa", "Condutor", b1 =>
                        {
                            b1.Property<int>("CotacaoSeguroVeicularId")
                                .HasColumnType("int");

                            b1.Property<string>("Cpf")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("CondutorCpf");

                            b1.Property<DateTime>("DataNascimento")
                                .HasColumnType("datetime2")
                                .HasColumnName("CondutorDataNascimento");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("CondutorNome");

                            b1.HasKey("CotacaoSeguroVeicularId");

                            b1.ToTable("COTACOES");

                            b1.WithOwner()
                                .HasForeignKey("CotacaoSeguroVeicularId");

                            b1.OwnsOne("SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects.Endereco", "Residencial", b2 =>
                                {
                                    b2.Property<int>("PessoaCotacaoSeguroVeicularId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Bairro")
                                        .IsRequired()
                                        .HasColumnType("varchar(50)")
                                        .HasColumnName("ProponenteBairro");

                                    b2.Property<string>("Cep")
                                        .IsRequired()
                                        .HasColumnType("varchar(15)")
                                        .HasColumnName("ProponenteCep");

                                    b2.Property<string>("Cidade")
                                        .IsRequired()
                                        .HasColumnType("varchar(150)")
                                        .HasColumnName("ProponenteCidade");

                                    b2.Property<string>("Estado")
                                        .IsRequired()
                                        .HasColumnType("varchar(2)")
                                        .HasColumnName("ProponenteEstado");

                                    b2.Property<string>("Rua")
                                        .IsRequired()
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("ProponenteRua");

                                    b2.HasKey("PessoaCotacaoSeguroVeicularId");

                                    b2.ToTable("COTACOES");

                                    b2.WithOwner()
                                        .HasForeignKey("PessoaCotacaoSeguroVeicularId");
                                });

                            b1.Navigation("Residencial")
                                .IsRequired();
                        });

                    b.OwnsOne("SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects.Pessoa", "Proprietario", b1 =>
                        {
                            b1.Property<int>("CotacaoSeguroVeicularId")
                                .HasColumnType("int");

                            b1.Property<string>("Cpf")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("ProprietarioCpf");

                            b1.Property<DateTime>("DataNascimento")
                                .HasColumnType("datetime2")
                                .HasColumnName("ProprietarioDataNascimento");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("ProprietarioNome");

                            b1.HasKey("CotacaoSeguroVeicularId");

                            b1.ToTable("COTACOES");

                            b1.WithOwner()
                                .HasForeignKey("CotacaoSeguroVeicularId");

                            b1.OwnsOne("SimulacaoSeguroVeicular.Domain.Simulacoes.Value_Objects.Endereco", "Residencial", b2 =>
                                {
                                    b2.Property<int>("PessoaCotacaoSeguroVeicularId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Bairro")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)")
                                        .HasColumnName("ProprietarioBairro");

                                    b2.Property<string>("Cep")
                                        .IsRequired()
                                        .HasMaxLength(8)
                                        .HasColumnType("nvarchar(8)")
                                        .HasColumnName("ProprietarioCep");

                                    b2.Property<string>("Cidade")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)")
                                        .HasColumnName("ProprietarioCidade");

                                    b2.Property<string>("Estado")
                                        .IsRequired()
                                        .HasMaxLength(2)
                                        .HasColumnType("nvarchar(2)")
                                        .HasColumnName("ProprietarioEstado");

                                    b2.Property<string>("Rua")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("ProprietarioRua");

                                    b2.HasKey("PessoaCotacaoSeguroVeicularId");

                                    b2.ToTable("COTACOES");

                                    b2.WithOwner()
                                        .HasForeignKey("PessoaCotacaoSeguroVeicularId");
                                });

                            b1.Navigation("Residencial")
                                .IsRequired();
                        });

                    b.OwnsOne("SimulacaoSeguroVeicular.Dominio.Simulacoes.Veiculo", "Veiculo", b1 =>
                        {
                            b1.Property<int>("CotacaoSeguroVeicularId")
                                .HasColumnType("int");

                            b1.Property<int>("Ano")
                                .HasColumnType("int")
                                .HasColumnName("VeiculoAno");

                            b1.Property<string>("Marca")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("VeiculoMarca");

                            b1.Property<string>("Modelo")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("VeiculoModelo");

                            b1.HasKey("CotacaoSeguroVeicularId");

                            b1.ToTable("COTACOES");

                            b1.WithOwner()
                                .HasForeignKey("CotacaoSeguroVeicularId");
                        });

                    b.Navigation("Condutor")
                        .IsRequired();

                    b.Navigation("Proprietario")
                        .IsRequired();

                    b.Navigation("Veiculo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
