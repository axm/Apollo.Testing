using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using System;

namespace Axm.Apollo.Testing.Extensions
{
    public static class TestExtensions
    {
        public static IServiceCollection WithMock<T>(this IServiceCollection services) where T : class => services.WithMock<T>((moq) => { });

        public static IServiceCollection WithMock<T>(this IServiceCollection services, Action<Mock<T>> setup) where T: class
        {
            var autoMocker = services.BuildServiceProvider().GetService<AutoMocker>();
            var mock = autoMocker.GetMock<T>();

            setup.Invoke(mock);

            services.AddTransient(provider => mock.Object);

            return services;
        }
    }
}
