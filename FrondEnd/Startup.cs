using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YourSolution.Data;

namespace YourSolution
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
      // Configuración de DbContext
      services.AddDbContext<YourDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      // Configuración de CORS
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAll",
            builder =>
            {
              builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
            });
      });

      // Configuración de la autenticación JWT
      var key = Encoding.ASCII.GetBytes("TuClaveSecretaSuperSegura"); // Reemplaza con una clave segura

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddControllersWithViews();
      services.AddScoped<IAuthService, AuthService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseStaticFiles(); // Sirve archivos estáticos desde wwwroot
        app.UseSpa(spa =>
        {
          spa.Options.SourcePath = "Frontend"; // Ruta a la aplicación Angular
          if (env.IsDevelopment())
          {
            spa.UseAngularCliServer(npmScript: "start");
          }
        });
      }
      else
      {
        // Configuraciones adicionales para entornos de producción
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles(); // Sirve archivos estáticos para la SPA
        app.UseSpa(spa =>
        {
          spa.Options.SourcePath = "Frontend";
        });
      }

      app.UseRouting();

      app.UseCors("AllowAll");

      // Agrega el middleware de autenticación y autorización aquí
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}

