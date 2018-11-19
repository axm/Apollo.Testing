using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;

namespace Axm.Apollo.Testing.Extensions
{
    public static class TestExtensions
    {
        public static IServiceCollection WithMock<T>(this IServiceCollection services) where T: class
        {
            var autoMocker = services.BuildServiceProvider().GetService<AutoMocker>();
            var mock = autoMocker.GetMock<T>();

            services.AddTransient(provider => mock.Object);

            return services;
        }
    }
}
