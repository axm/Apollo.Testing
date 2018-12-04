using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Axm.Apollo.Testing.Samples.Services
{
    public class StudentService : IStudentService
    {
        private IStudentValidation Validation;
        private IStudentRepository Repository;

        public StudentService(IStudentValidation validation, IStudentRepository repository)
        {
            Validation = validation;
            Repository = repository;
        }

        public Task CreateAsync(Student student)
        {
            if(!Validation.IsValid(student))
            {
                throw new InvalidOperationException();
            }

            return Repository.CreateAsync(student);
        }
    }

    public interface IStudentService { Task CreateAsync(Student student); }

    public class Student
    {

    }

    public class StudentValidation : IStudentValidation
    {
        public bool IsValid(Student student) => student != null;
    }

    public interface IStudentValidation
    {
        bool IsValid(Student student);
    }

    public class StudentRepository : IStudentRepository
    {
        public Task CreateAsync(Student student) => Task.CompletedTask;
    }

    public interface IStudentRepository
    {
        Task CreateAsync(Student student);
    }
}
