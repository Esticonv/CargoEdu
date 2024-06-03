using R7P.MachineManagerService.WebSimulator.Components;

namespace R7P.MachineManagerService.WebSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<NotifierService>();
            builder.Services.AddSingleton<TimerService>();

            builder.WebHost.UseStaticWebAssets();

            //string connectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] 
            //    ?? throw new InvalidOperationException("Not found connection string");

            var connectionString = string.Empty;

            builder.Services.AddHttpClient("WebAPI", client =>
                client.BaseAddress = new Uri(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
