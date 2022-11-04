using System.Text;
using System.Text.Json.Serialization;
using Application.DTOs;
using Application.Helpers;
using Application.InterfacesRepos;
using Application.InterfacesServices;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
var mapper = new MapperConfiguration(config =>
{
    config.CreateMap<PostBoxDTO, Box>();
    config.CreateMap<PutBoxDTO, Box>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite("Data Source =db.db"));
builder.Services.AddScoped<RepositoryDBContext>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();
builder.Services.AddScoped<IBoxService, BoxService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetValue<string>("AppSettings:Secret")))
    };
});

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

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();