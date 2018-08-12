using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using task3.Attributes;
using task3.Loggers;
using task3.Services;
using AutoMapper;
using task3.Domain.EF;

namespace task3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddAutoMapper();
            services.AddDbContext<FilmsStoreDbContext>(options => options.UseSqlServer(connection));
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            services.AddTransient<IFilmService, FilmService>();
            services.AddTransient<IActionLogger, FileLogger>();
            services.AddScoped<ActionAttribute>();
            services.AddScoped<ExceptionAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
