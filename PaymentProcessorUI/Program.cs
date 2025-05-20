using System.Text.Json.Serialization;
using PaymentProcessor.Extensions;
using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Processor;
using PaymentProcessor.Processor.Context;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Requests.Mappers;
using PaymentProcessor.Serializers;

namespace PaymentProcessor
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AddServices(builder.Services);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            //app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=CardPayment}/{action=Index}/{id?}");

            app.Run();
        }

        private static void AddServices(IServiceCollection services)
        {
            
            // Add services to the container.
            services.AddMvcCore();

            services.AddControllers()
                .AddJsonOptions(jsonOptions =>
                    jsonOptions.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString
                );

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            services.AddScoped<IProcessRunner, ProcessRunner>();
            //services.AddScoped<IProcessStepFactory, ProcessStepFactory>();
            services.AddScoped<IProcessContext, ProcessContext>();
            services.AddScoped<IMessageSerializer, StringSerializer>();
            //services.AddScoped<IMapperFactory, MapperFactory>();
            services.AddChildClasses(typeof(IMapper), typeof(IProcessStep));

            services.AddScoped<ProcessStepFactory>(serviceProvider =>
            {
                return (type) => (IProcessStep)serviceProvider.GetRequiredService(type);
            });

            services.AddScoped<MapperFactory>(serviceProvider =>
            {
                return (type) => (IMapper)serviceProvider.GetRequiredService(type);
            });
        }
    }
}
