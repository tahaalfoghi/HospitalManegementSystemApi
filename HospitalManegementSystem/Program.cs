
using HospitalManegementSystem.Data;
using HospitalManegementSystem.Mapping;
using HospitalManegementSystem.Middlewars;
using HospitalManegementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace HospitalManegementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(op=> op.Filters.Add<LogSensitiveAction>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(
                op=>op.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<ProfilingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
