using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RagnarokAPI.DataBaseSettings;
using RagnarokAPI.Service;

namespace RagnarokAPI
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
            services.Configure<MonsterDatabaseSettings>(
                Configuration.GetSection(nameof(MonsterDatabaseSettings)));

            services.Configure<ItemDatabaseSettings>(
                Configuration.GetSection(nameof(ItemDatabaseSettings)));

            services.AddSingleton<IMonsterDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MonsterDatabaseSettings>>().Value);

            services.AddSingleton<IItemDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ItemDatabaseSettings>>().Value);

            services.AddSingleton<MonsterService>();
            services.AddSingleton<ItemService>();
            services.AddControllers();
        }

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
        }
    }
}
