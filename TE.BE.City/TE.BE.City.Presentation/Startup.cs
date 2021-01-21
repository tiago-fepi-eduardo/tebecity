using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Domain;
using TE.BE.City.Infra.Data;
using TE.BE.City.Infra.Data.Repository;
using TE.BE.City.Service.Services;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Presentation
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup method
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration method
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "City API"
                });
            });
                        
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TEBECityContext>(options => {
                options.UseMySql(connectionString, options => options.EnableRetryOnFailure());
                options.EnableDetailedErrors();
            });

            // Dependency injection
            services.AddScoped(typeof(TEBECityContext));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));
            services.AddScoped(typeof(IOrderDomain), typeof(OrderDomain));

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "RDI Token API"); });

            app.UseMvc();

            // Set swagger as default page
            app.Run(async context => {
                context.Response.Redirect("swagger/index.html");
            });
        }

        private void CheckConnections()
        {
            //var sqlCon = new SqlConnection(Properties.Settings.Default.sString);
            //sqlCon.Open();
            /*
            var mySQLCon = new MySqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            mySQLCon.Open();
            var temp = mySQLCon.State.ToString();
            
            if (mySQLCon.State == ConnectionState.Open && temp == "Open")
            {
                //MessageBox.Show(@"Connection working.");
            }
            else
            {
                //MessageBox.Show(@"Please check connection string");
            }
            */
        }
    }
}
