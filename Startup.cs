using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Port=3306;Database=test;Uid=test-dev;Pwd=test1234");
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            context.Database.Migrate();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    }