using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fire.Models;
using Firebase.Database;

namespace Fire.Data_Access.Repositories
{
    public interface IFirebaseRepository
    {
        public Task<bool> ExistsStudent(string name);
        public Task<bool> RemoveStudent(string student);

        public Task<bool> AddStudent(Student student);
        public Task<Student> GetStudent(string name);
        public Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents();

        
    }
}
