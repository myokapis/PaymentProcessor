using System.Text.Json.Serialization;
using Payment.Messages.Factories.Delegates;
using Payment.Messages.Mappers;
using Payment.Messages.Serializers;
using Payment.Messages.Serializers.Formatters;
using Payment.Processor.Builders;
using Payment.Processor.Transaction.Context;
using Payment.Workflow.Factories.Delegates;
using Payment.Workflow.Interfaces;
using TsysProcessor.Extensions;
using TsysProcessor.Processor;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Workflow.Context;

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
            services.AddScoped<TsysWorkflowContext>();
            services.AddScoped<IMessageSerializer, StringMessageSerializer>();
            services.AddScoped<IStringMessageSerializer, StringMessageSerializer>();
            services.AddScoped<IBuilder<ActionContext>, ActionContextBuilder>();
            services.AddScoped<IFormatter, Formatter>();
            services.AddChildClasses(typeof(IMapper), typeof(IWorkflowTask));

            services.AddScoped<WorkflowTaskFactory>(serviceProvider =>
            {
                return (type) => (IWorkflowTask)serviceProvider.GetRequiredService(type);
            });

            services.AddScoped<MapperFactory<TsysTransactionContext>>(serviceProvider =>
            {
                return (type) => (IMapper<TsysTransactionContext>)serviceProvider.GetRequiredService(type);
            });
        }
    }
}
