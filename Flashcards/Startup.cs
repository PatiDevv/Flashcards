using Flashcards.Infrastructure.IRepositories;
using Flashcards.Infrastructure.IServices;
using Flashcards.Infrastructure.Mappers;
using Flashcards.Infrastructure.Repositories;
using Flashcards.Infrastructure.Services;
using Flashcards.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Flashcards
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddControllers();
            services.AddScoped<IFlashcardRepository, FlashcardRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFlashcardService, FlashcardService>();
            services.AddScoped<IDataInitializer, DataInitializer>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<AppSettings>(Configuration.GetSection("app"));

            // Pobranie appsetingsow (appsetings.json)
            var jwtSettingsSection = Configuration.GetSection(typeof(JwtSettings).Name);

            // Zmapowanie appsetingsów na klase AppSettings
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = jwtSettings.Issuer
                };
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            SeedData(app);
        }

        private void SeedData(IApplicationBuilder app)
        {
            var appSettingsSection = Configuration.GetSection(typeof(AppSettings).Name);
            var settings = appSettingsSection.Get<AppSettings>();
            if (settings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }

        }
    }
}
