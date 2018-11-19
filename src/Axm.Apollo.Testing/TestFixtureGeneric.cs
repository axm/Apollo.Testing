using System;
using Microsoft.Extensions.DependencyInjection;

namespace Axm.Apollo.Testing
{
    public abstract class TestFixture<T> : BaseTestFixture where T : class
    {
        protected T Sut { get; }

        public TestFixture()
        {
            if (!typeof(T).IsInterface)
                throw new InvalidOperationException($"{nameof(T)} must be an interface.");

            Sut = CreateSut();
        }

        protected virtual T CreateSut() => GetService<T>();
    }
}
