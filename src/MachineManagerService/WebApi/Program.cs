using R7P.MachineManagerService.Application;
using R7P.MachineManagerService.Infrastructure.EntityFramework;
using R7P.MachineManagerService.Infrastructure.Repository;

namespace R7P.MachineManagerService.WebApi
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.            
            builder.Services.AddApplicationServices(builder.Configuration);
            

            builder.Services.AddInfrastructureEFServices(builder.Configuration); 
            builder.Services.AddInfrastructureRepositoryServices(builder.Configuration);            

            //Add web services
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseAuthorization();


            app.MapControllers();

            app.Services.InitializeDatabaseAsync();

            app.Run();
        }
    }
}
