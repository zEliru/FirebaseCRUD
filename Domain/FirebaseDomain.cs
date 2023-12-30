using Fire.Data_Access.Repositories;
using Fire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Domain
{
    public class FirebaseDomain : IFirebaseDomain
    {
        IFirebaseRepository fr { get; set; }
        public FirebaseDomain() 
        {
            fr = FirebaseFactory.CreateFirebaseRepository();
        }
        public Task<bool> AddStudent(Student student)
        {
            return fr.AddStudent(student);
        }

        public Task<bool> ExistsStudent(string name)
        {
            return fr.ExistsStudent(name);
        }

        public async Task<List<Student>> GetListStudents()
        {
            List<Student> sts = new List<Student>();
            var w =  await fr.GetStudents();
            foreach (var t in w)
            {
                t.Object.Name = t.Object.FullName.Split(' ')[0];
                t.Object.Surname = t.Object.FullName.Split(' ')[1];
                sts.Add(t.Object);
            }

            return sts;
        }

        public Task<Student> GetStudent(string name)
        {
            return fr.GetStudent(name);
        }

        public Task<Student> GetStudent(Student student)
        {
            return fr.GetStudent(student.FullName);
        }

        public Task<bool> RemoveStudent(string name)
        {
            return fr.RemoveStudent(name);
        }

        public Task<bool> RemoveStudent(Student student)
        {
            return fr.RemoveStudent(student.FullName);
        }
    }
}
