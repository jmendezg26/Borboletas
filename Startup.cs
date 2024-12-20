using Borboletas.AccesoDatos;

namespace Borboletas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            environment = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(_ => Configuration);
            services.AddCors(options => options.AddPolicy("AllowWebApp", builder =>
                builder
                    .WithOrigins("http://192.168.0.24:83", "http://localhost:83/", "http://localhost:4200", "http://192.168.100.16:7072") // URL de tu frontend
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowCredentials())); // Solo orígenes específicos con credenciales
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseWebSockets();


            //app.UseAuthorization();
            app.UseCors("AllowWebApp");
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            BDConexion.SetDBConfiguration(Configuration);
        }
    }
}
