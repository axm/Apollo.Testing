using System.Threading.Tasks;

namespace Axm.Apollo.Testing.Samples.Services
{
    public interface IStudentService
    {
        Task CreateAsync(Student student);
    }
}
