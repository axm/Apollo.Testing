using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using System;

namespace Axm.Apollo.Testing.Extensions
{
    public static class TestExtensions
    {
        public static IServiceCollection AddMock<T>(this IServiceCollection services) where T : class => services.AddMock<T>((moq) => { });

        public static IServiceCollection AddMock<T>(this IServiceCollection services, Action<Mock<T>> setup) where T: class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (setup == null)
                throw new ArgumentNullException(nameof(setup));

            var autoMocker = services.BuildServiceProvider().GetService<AutoMocker>();
            var mock = autoMocker.GetMock<T>();

            setup.Invoke(mock);

            services.AddTransient(provider => mock.Object);

            return services;
        }
    }
}
