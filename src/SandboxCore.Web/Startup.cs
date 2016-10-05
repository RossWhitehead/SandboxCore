using System.Globalization;
using System.Linq;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SandboxCore.Commands;
using SandboxCore.Commands.Product.Create;
using SandboxCore.Data;
using SandboxCore.Queries;
using Scrutor;

namespace SandboxCore.Web
{
    public class Startup
    {
        private ILoggerFactory loggerFactory;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.loggerFactory = new LoggerFactory();
            loggerFactory.AddNLog();

            services.AddSingleton<ILoggerFactory>(loggerFactory);

            // Add framework services.
            services.AddMvc()
                    .AddMvcOptions(o => { o.Filters.Add(new GlobalExceptionFilter(loggerFactory)); })
                    .AddViewLocalization()
                    .AddDataAnnotationsLocalization()
                    .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<ICommand>(); });

            // Must be included .AddMvc
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            });

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            var mapper = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new[]
                {
                    "SandboxCore.Queries",
                    "SandboxCore.Commands"
                })).CreateMapper();

            services.AddSingleton<IMapper>(mapper);

            var connection = @"Server=(localdb)\mssqllocaldb;Database=SandboxCore;Trusted_Connection=True;";
            services.AddDbContext<CommandDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<QueryDbContext>(options => options.UseSqlServer(connection));

            //
            // Mediator pattern
            //
            services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
            services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

            // Use Scrutor to scan and register all classes as their implemented interfaces.
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator), typeof(Handler))
                .AddClasses()
                .AsImplementedInterfaces());

            //
            // CommandDispatcher and QueryDispatcher
            //
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IQueryHandler<,>), typeof(ICommandHandler<>))
                .AddClasses()
                .AsImplementedInterfaces());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var supportedCultures = new[]
            {
                new CultureInfo("es"),
                new CultureInfo("es-MX")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            env.ConfigureNLog("nlog.config");
        }
    }
}
