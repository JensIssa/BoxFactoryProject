using System.Text.Json.Serialization;
using Application.DTOs;
using Application.InterfacesRepos;
using Application.InterfacesServices;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
var mapper = new MapperConfiguration(config =>
{
    config.CreateMap<PostBoxDTO, Box>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite("Data Source =db.db"));
builder.Services.AddScoped<RepositoryDBContext>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();
builder.Services.AddScoped<IBoxService, BoxService>();
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