using Axm.Apollo.Testing.Samples.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Axm.Apollo.Testing.Extensions;
using System.Threading.Tasks;
using Moq;

namespace Axm.Apollo.Testing.Samples
{
    public class CreateAsync : TestFixture<IStudentService>
    {
        [Fact]
        public async Task When_Validation_Fails_Throws_InvalidOperationException()
        {
            SetUp_When_Validation_Fails_Throws_InvalidOperationException();

            await Assert.ThrowsAsync<InvalidOperationException>(() => Sut.CreateAsync(new Student()));
        }

        private void SetUp_When_Validation_Fails_Throws_InvalidOperationException()
        {
            GetMock<IStudentValidation>()
                .Setup(_ => _.IsValid(It.IsAny<Student>()))
                .Returns(false);
        }

        protected override void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.WithMock<IStudentValidation>();
            services.WithMock<IStudentRepository>();
        }
    }
}
