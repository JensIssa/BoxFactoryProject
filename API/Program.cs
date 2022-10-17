using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlServer("HAVE TO GET A SQL SERVER"));

// Add services to the container.
var config = new MapperConfiguration(conf =>
{
    conf.CreateMap<PostBoxDTO, Box>();
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddControllers();
builder.Services.AddScoped<RepositoryDBContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Application.DependencyResolver.
    DepedencyResolverService.
    RegisterApplicationLayer(builder.Services);

Infrastructure.DepedencyResolver.DepedencyResolver.RegisterInfrastructure(builder.Services);

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