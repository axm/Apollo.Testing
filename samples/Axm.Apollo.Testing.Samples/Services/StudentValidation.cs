namespace Axm.Apollo.Testing.Samples.Services
{
    public class StudentValidation : IStudentValidation
    {
        public bool IsValid(Student student) => student != null;
    }
}
