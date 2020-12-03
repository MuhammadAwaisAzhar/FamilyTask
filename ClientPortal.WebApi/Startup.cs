using AutoMapper;
using ClientPortal.Data;
using ClientPortal.Mapper;
using ClientPortal.Repositories.Implementations;
using ClientPortal.Repositories.Interfaces;
using ClientPortal.Services.Implementations;
using ClientPortal.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientPortal.WebApi
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<FamilyTasksContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FamilyTasksDBConnection"),builder=>builder.MigrationsAssembly("ClientPortal.Data")));

            services.AddScoped<DbContext, FamilyTasksContext>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MembersMappingProfile());
                mc.AddProfile(new TasksMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IMembersRepository, MembersRepository>();
            services.AddTransient<ITasksRepository, TasksRepository>();
            services.AddTransient<IMembersService, MembersService>();
            services.AddTransient<ITasksService, TasksService>();
            // Register the Swagger services
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            UpdateDatabase(applicationBuilder);
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
            // Register the Swagger generator and the Swagger UI middlewares
            applicationBuilder.UseOpenApi();
            applicationBuilder.UseSwaggerUi3();
            applicationBuilder.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void UpdateDatabase(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FamilyTasksContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
