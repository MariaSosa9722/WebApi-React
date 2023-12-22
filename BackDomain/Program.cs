using Microsoft.EntityFrameworkCore;
using WepApi.Context;
using WepApi.Services.IServices;
using WepApi.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Integración de CorsPolicy

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", // This is the open house we talked about!
        builder =>
        {
            builder.AllowAnyOrigin() // Any origin is welcome...
                .AllowAnyHeader() // With any type of headers...
                .AllowAnyMethod(); // And any HTTP methods. Such a jolly party indeed!
        });
});



//Register services here
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

//Inyección de dependencias

builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();


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
