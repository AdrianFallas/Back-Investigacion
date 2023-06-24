using Investigacion.Aplicacion;
using Investigacion.Domain;
using Investigacion.Infraestructura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace Backend_Investigacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var proveedor = builder.Services.BuildServiceProvider();
            var configuration = proveedor.GetService<IConfiguration>();


            // Register DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register your custom dependencies
            builder.Services.AddScoped<IPersonRepository<Person>, PersonRepository>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            // Otros servicios personalizados

            builder.Services.AddCors(opciones =>
            {
                var frontendURL = configuration.GetValue<string>("frontendURL");


                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
                }
                );
            }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
