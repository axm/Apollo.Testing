using System.Threading.Tasks;

namespace Axm.Apollo.Testing.Samples.Services
{
    public class StudentRepository : IStudentRepository
    {
        public Task CreateAsync(Student student) => Task.CompletedTask;
    }
}
