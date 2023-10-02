using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using TestApiRest.Headers;
using TestApiRest.Repository;
using TestApiRest.Repository.Interfaces;
using TestApiRest.Services;
using TestApiRest.Services.Interfaces;
using Utils.Middleware;

namespace TestApiRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"),
                options => options.MigrationsAssembly("Repository"))); //Para que la carpeta Migrations Se genere en Repository
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Prueba Api Rest",
                    Description = "Esta app registra pedidos de clientes y libros."
                });
                c.OperationFilter<ApiKeyHeader>();
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddCors(options =>
            {
                options.AddPolicy("Policy",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            services.AddScoped<IBooksService, BooksService>();  
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IOrdersService, OrdersService>();  

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ValidatorMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
