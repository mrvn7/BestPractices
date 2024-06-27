using BestPractices.API.Controllers;
using BestPractices.Application.Interfaces;
using BestPractices.Application.Mapper;
using BestPractices.Application.Services;
using BestPractices.Domain.Repositories;
using BestPractices.Domain.Repositories.UnitOfWork;
using BestPractices.Infraestructure.Data.DbContextConfig;
using BestPractices.Infraestructure.Data.Repositories;
using BestPractices.Infraestructure.Data.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Swagger - Api de boas praticas utilizando .Net",
            Description = "Esse projeto tem como intuito demonstrar boas praticas na criação de uma API usando .net",
            Contact = new OpenApiContact() { Name = "Marcus Vinicius Oliveira", Email = "marcusoliveirati@gmail.com" },
            License = new OpenApiLicense()
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });
    }
);

// Configurar o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adicionando configuração de logger
builder.Services.AddLogging();

//Adicionando configuração de injeção de dependencia para as minhas Interfaces e classes que as herdam.
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Adicionando configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));

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