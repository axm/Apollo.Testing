using System;
using Microsoft.Extensions.DependencyInjection;

namespace Axm.Apollo.Testing
{
    public abstract class TestFixture<T> : BaseTestFixture where T : class
    {
        protected T Sut { get; }

        public TestFixture() => Sut = CreateSut();

        protected virtual T CreateSut()
        {
            // not necessary?
            //if (typeof(T).IsClass)
            //    return AutoMocker.CreateInstance<T>();

            // interface
            return GetService<T>();
        }
    }
}
