using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using L4U_WebService.Utilities;

namespace L4U_WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }



        //metodo para ser chamado pelo runtime. neste metodo adiciona-se serviços ao controlador
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            //services.AddSingleton<IConfiguration>(Configuration);

            services.AddControllers();
            services.AddCors(o => o.AddPolicy("l4uPolicy", builder =>
            {
                //builder.AllowAnyOrigin();
                builder.WithOrigins("*", "http://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();

            }));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<User>();



        }



    }
}
