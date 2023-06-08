

using Microsoft.EntityFrameworkCore;
using VideoGamesBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// guardamos del nombre de la base de datos
const string ConectionName = "VideogamesApiDB";
// obtenemos la ruta de coenccion a la base de datos
var conectionString = builder.Configuration.GetConnectionString(ConectionName);
// añadimos el servicio para utilizar SqlServer y la base de datos
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//options.UseSqlServer(conectionString);
//});

// llamo a la clase de DbContext que se encarga de cargar y guardar los videojeugos traidos de la API a base de datos
var gameController = new GameController();
await gameController.SaveVideogamesToDB();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

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
