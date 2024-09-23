using PersistencePoc.Infra.Dapper.Interfaces;
using PersistencePoc.Infra.Dapper.Repositories;

namespace PersistencePoc.Api
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
            builder.Services.AddScoped<Infra.EntityFrameworkSix.Context.DatabaseContext>();

            // Change DatabaseContext registration to Scoped
            builder.Services.AddScoped(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                return new Infra.Dapper.Context.DatabaseContext(configuration);
            });

            builder.Services.AddScoped<IConcessionariaDapperRepository, ConcessionariaDapperRepository>();
            builder.Services.AddMemoryCache();

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
        }
    }
}

