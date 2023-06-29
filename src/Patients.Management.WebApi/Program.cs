using MongoDB.Driver;
using Patients.Management.Application.AutoMappers;
using Patients.Management.Application.Services;
using Patients.Management.Infrastructure.Database;
using Patients.Management.Infrastructure.Repositories;

namespace Patients.Management.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.Services.AddSingleton(options =>
            {
                var mongoDbSettings = new MongoDbSettings();

                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MongoDbSettings__ConnectionString")) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MongoDbSettings__DatabaseName")))
                {
                    mongoDbSettings.ConnectionString = Environment.GetEnvironmentVariable("MongoDbSettings__ConnectionString");
                    mongoDbSettings.DatabaseName = Environment.GetEnvironmentVariable("MongoDbSettings__DatabaseName");
                }
                else
                {
                    mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
                }

                var client = new MongoClient(mongoDbSettings?.ConnectionString);

                return client.GetDatabase(mongoDbSettings?.DatabaseName);
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IPatientRepository, PatientRepository>();

            builder.Services.AddScoped<IPatientService, PatientService>();

            var app = builder.Build();

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}