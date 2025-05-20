using System.Reflection;

namespace PaymentProcessor.Extensions
{
    public static class ServicesExtensions
    {
        // TODO: rename this method
        public static IServiceCollection AddChildClasses(this IServiceCollection services, params Type[] baseTypes)
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null) return services;

            var childClasses = assembly.GetTypes()
                .Where(t => baseTypes.Any(b => (t != b) && (b.IsAssignableFrom(t))) && t.IsClass && !t.IsAbstract);

            foreach (var childClass in childClasses)
            {
                services.AddScoped(childClass);
            }

            return services;
        }

        public static IServiceCollection AddChildClasses(this IServiceCollection services, Type parentType, Action<Type, IServiceCollection> registrar)
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null) return services;

            var childClasses = assembly.GetTypes()
                .Where(t => (t != parentType) && (parentType.IsAssignableFrom(t)) && t.IsClass);

            foreach (var childClass in childClasses)
            {
                registrar(childClass, services);
            }

            return services;
        }
    }
}
