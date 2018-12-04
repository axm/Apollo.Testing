using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;

namespace Axm.Apollo.Testing
{
    public abstract class BaseTestFixture
    {
        protected IServiceProvider Services { get; private set; }
        protected AutoMocker AutoMocker { get; } = new AutoMocker();

        public BaseTestFixture()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            var services = new ServiceCollection();
            RegisterCoreServices(services);
            RegisterServices(services);

            Services = ResolveServiceProvider(services);
        }

        private void RegisterCoreServices(IServiceCollection services)
        {
            services.AddSingleton(AutoMocker);
        }

        protected virtual void RegisterServices(IServiceCollection services) { }

        protected virtual IServiceProvider ResolveServiceProvider(IServiceCollection services) => services.BuildServiceProvider();

        protected Mock<T> GetMock<T>() where T: class => AutoMocker.GetMock<T>();
        protected T GetService<T>() where T : class => Services.GetService<T>();
    }
}
