using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fire.Models;

namespace Fire.Domain
{
    public interface IFirebaseDomain
    {
        public Task<bool> ExistsStudent(string name);
        public Task<bool> AddStudent(Student student);
        public Task<bool> RemoveStudent(string name);
        public Task<bool> RemoveStudent(Student student);
        public Task<Student> GetStudent(string name);
        public Task<Student> GetStudent(Student student);
        public Task<List<Student>> GetListStudents();
    }
}
