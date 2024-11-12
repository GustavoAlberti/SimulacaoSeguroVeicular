using Microsoft.EntityFrameworkCore;
using SimulacaoSeguroVeicular.Domain.Simulacoes;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Features.FluxoAprovacaoCotacao;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Services;
using SimulacaoSeguroVeicular.Extensions;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CotacaoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped <CotacaoRepositorio>();
builder.Services.AddScoped<CriarCotacaoHandler>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<AprovarCotacaoHandler>();
builder.Services.AddScoped<ReprovarCotacaoHandler>();


builder.Services.AddWorkflow();
builder.Services.AddWorkflowSteps();
builder.Services.AddTransient<CotacaoWorkFlow>();
builder.Services.AddScoped<FakeTabelaFipeService>();
builder.Services.AddScoped<FakeConsultarHistoricoAcidentesService>();
builder.Services.AddScoped<CalculaPontuacaoNivelRiscoService>();
builder.Services.AddScoped<ValorSeguroService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Obtém o WorkflowHost e registra o workflow
var workflowHost = app.Services.GetRequiredService<IWorkflowHost>();
workflowHost.RegisterWorkflow<CotacaoWorkFlow, CotacaoWorkflowData>(); // Registra o workflow
workflowHost.Start();

// Garante que o WorkflowHost será parado quando a aplicação for encerrada
app.Lifetime.ApplicationStopped.Register(() => workflowHost.Stop());

app.Run();
