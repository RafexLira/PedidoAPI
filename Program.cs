using Microsoft.EntityFrameworkCore;
using PedidosAPI.Application.Services;
using PedidosAPI.Domain.Interfaces;
using PedidosAPI.Infra.Data;
using PedidosAPI.Infra.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PedidosDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

//repo
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

//service
builder.Services.AddScoped<PedidoAppService>();
builder.Services.AddScoped<ProdutoAppService>();

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

app.Run();
