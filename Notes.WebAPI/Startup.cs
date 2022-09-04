using Notes.Application;
using Notes.Application.Common.AutoMapper;
using Notes.Persistence;
using Notes.WebAPI.Middleware;

namespace Notes.WebAPI
{
    public class Startup
    {
        private const string CORSPolicyName = "AllowAll";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new NotesMapping());
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(CORSPolicyName, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(CORSPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
