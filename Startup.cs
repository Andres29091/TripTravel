using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NRWeb.Interfaces.Log;
using TripTravel.Data;
using TripTravel.Servicios;

namespace TripTravel
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
      services.AddControllers();

      services.AddAutoMapper(typeof(Startup));
      services.AddTransient<ILogService, LogService>();
      services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
      services.AddHttpContextAccessor();
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiTripTravel", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

      }
      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTripTravel v1"));

      app.UseHttpsRedirection();

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
