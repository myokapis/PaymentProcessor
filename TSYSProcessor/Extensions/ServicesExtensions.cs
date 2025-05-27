using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentProcessor.Extensions
{
    public static class ServicesExtensions
    {
        // TODO: rename this method
        public static IServiceCollection AddChildClasses(this IServiceCollection services, params Type[] baseTypes)
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly == null) return services;

            var childClasses = assembly.GetTypes()
                .Where(t => baseTypes.Any(b => (t != b) && (b.IsAssignableFrom(t))) && t.IsClass && !t.IsAbstract);

            foreach (var childClass in childClasses)
            {
                services.AddScoped(childClass);
            }

            return services;
        }
    }
}
