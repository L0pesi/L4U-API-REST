using L4U_BOL_MODEL.Models;
using L4U_WebService.Utilities;
using Microsoft.OpenApi.Models;

namespace L4U_WebService
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

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.3", new OpenApiInfo
                {
                    Title = "L4U API WebService",
                    Version = "v0.3",
                    Description = "L4U com Documentação OpenAPI",
                    Contact = new OpenApiContact
                    {
                        Name = " Integração e Sistemas de Informação 2022/23",
                        Email = string.Empty,
                        Url = new Uri("https://elearning1.ipca.pt/"),
                    },
                });

            });

        }



        //metodo para ser chamado no runtime. neste metodo configura-se o HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "L4U API WebService v0.3"));
            }

            app.UseCors("l4uPolicy");

            app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            //app.UseAuthentication(); //para suportar o JWT

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

    }
}
