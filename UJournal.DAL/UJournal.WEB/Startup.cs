using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using UJournal.Model.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UJournal.DAL.Behavior;
using UJournal.DAL.Service;
using UJournal.Model.Behavior;
using UJournal.Model.Models;

namespace UJournal.DAL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<UJournalContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("UJournal"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    }    
                );
            });
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }

        
    }
}
