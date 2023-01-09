using Notes.Persistence;
using Serilog;
using Serilog.Events;

namespace Notes.WebAPI
{
    /// <summary>
    /// Entry class of thee application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application's entry point.
        /// </summary>
        /// <param name="args">Startup parameters.</param>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("NotesWebApiLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<NotesDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Application gas been crashed while inintialization");
                }
            }

            host.Run();
        }

        /// <summary>
        /// Sets up Host for application.
        /// </summary>
        /// <param name="args">Parameters.</param>
        /// <returns>Host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
