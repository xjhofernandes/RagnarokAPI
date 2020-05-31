using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RagnarokAPI.DataBaseSettings;
using RagnarokAPI.Models;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MonsterDatabaseSettingsFix>(
                Configuration.GetSection(nameof(MonsterDatabaseSettingsFix)));

            services.Configure<ItemDatabaseSettingsFix>(
                Configuration.GetSection(nameof(ItemDatabaseSettingsFix)));

            services.AddSingleton<IMonsterDatabaseSettingsFix>(sp =>
                sp.GetRequiredService<IOptions<MonsterDatabaseSettingsFix>>().Value);

            services.AddSingleton<IItemDatabaseSettingsFix>(sp =>
                sp.GetRequiredService<IOptions<ItemDatabaseSettingsFix>>().Value);

            services.AddSingleton<MonstersService>();
            services.AddSingleton<ItemsService>();

            services.AddControllers();
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
        }
    }
}
