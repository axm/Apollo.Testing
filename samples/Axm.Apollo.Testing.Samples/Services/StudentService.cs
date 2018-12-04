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
}
