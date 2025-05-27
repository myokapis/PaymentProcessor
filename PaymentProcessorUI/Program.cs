using System.Text.Json.Serialization;
using PaymentProcessor.Builders;
using PaymentProcessor.Extensions;
using PaymentProcessor.Factories.Delegates;
using PaymentProcessor.Mappers;
using PaymentProcessor.Processor.ProcessStep;
using PaymentProcessor.Serializers;
using PaymentProcessor.Serializers.Formatters;
using PaymentProcessor.Serializers.String;
using PaymentProcessor.Transaction.Context;
using TsysProcessor.Processor;
using TsysProcessor.Processor.Context;

namespace PaymentProcessorUI
{
    public class Program
    {
        // TODO: add configuration for database connections
        //       add Dapper
        //       add logging and monitoring
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

            services.AddScoped<TsysTransactionRunner>();
            services.AddScoped<TsysProcessContext>();
            services.AddScoped<IMessageSerializer, StringSerializer>();
            services.AddScoped<IBuilder<ActionContext>, ActionContextBuilder>();
            services.AddScoped<IFormatter, Formatter>();
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
