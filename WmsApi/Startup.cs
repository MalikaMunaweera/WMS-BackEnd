using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WmsApi.Business;
using WmsApi.Common.Interfaces;
using WmsApi.Data;
using WmsApi.Data.Entities;

namespace WmsApi
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
            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
            }));

            services.AddMvc();

            services.AddScoped<DbContext, WMSContext>();
            services.AddScoped<IProjectBusiness, ProjectBusiness>();
            services.AddScoped<IProjectDataAccess, ProjectDataAccess>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserDataAccess, UserDataAccess>();
            services.AddScoped<IUserStoryBusiness, UserStoryBusiness>();
            services.AddScoped<IUserStoryDataAccess, UserStoryDataAccess>();
            services.AddScoped<IWorkFlowBusiness, WorkFlowBusiness>();
            services.AddScoped<IWorkFlowDataAccess, WorkFlowDataAccess>();
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
