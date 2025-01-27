using ApiFilms.Data;
using ApiFilms.FilmMapper;
using ApiFilms.Repository;
using ApiFilms.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repository
builder.Services.AddScoped<IRespositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IRespositoryFilm, RepositoryFilm>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(FilmMapper));

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
