﻿using System.Threading.Tasks;

namespace Axm.Apollo.Testing.Samples.Services
{
    public interface IStudentRepository
    {
        Task CreateAsync(Student student);
    }
}
