using Application.DTOs;
using Application.InterfacesServices;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());



// Add services to the container.
var config = new MapperConfiguration(conf =>
{
    conf.CreateMap<PostBoxDTO, Box>();
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite("Data Source =../Infrastructure/db.db"));
builder.Services.AddScoped<RepositoryDBContext>();
builder.Services.AddScoped<BoxRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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