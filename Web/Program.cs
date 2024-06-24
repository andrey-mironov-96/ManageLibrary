
using Application.Behaviors;
using Domain.Abstractions;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IServiceCollection services = builder.Services;
            ConfigurationManager configuration = builder.Configuration;

            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
            services.AddControllers().AddApplicationPart(presentationAssembly);

            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(applicationAssembly);
                x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));
            });


            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));
            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddSwaggerGen();
            //services.AddSwaggerGen(c =>
            //{
            //    var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

            //    var presentationDocumentationFilePath =
            //        Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

            //    c.IncludeXmlComments(presentationDocumentationFilePath);

            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
            //});

            var connectionString = configuration.GetSection("ConnectionString");
            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseNpgsql(connectionString.Value));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookcaseRepository, BookcaseRepository>();
            services.AddScoped<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationDbContext>());

            var app = builder.Build();

            await MakeMigrations(app.Services);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #region default init web app
            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            //await MakeMigrations(app.Services);

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            //app.Run();
            #endregion
        }

        private static async Task MakeMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
