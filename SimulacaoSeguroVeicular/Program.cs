using Microsoft.EntityFrameworkCore;
using SimulacaoSeguroVeicular.Domain.Simulacoes;
using SimulacaoSeguroVeicular.Domain.Simulacoes.Application.Handlers;
using SimulacaoSeguroVeicular.Infrastructure.Data;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CotacaoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped <CotacaoRepositorio>();
builder.Services.AddScoped<CriarCotacaoHandler>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddWorkflow();

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

var workflowHost = app.Services.GetRequiredService<IWorkflowHost>();
workflowHost.Start();
//entender melhor
app.Lifetime.ApplicationStopped.Register(() => workflowHost.Stop());

app.Run();
