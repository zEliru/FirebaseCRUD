using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get
            {
                return Name + " " + Surname;
            }
        }
        public int Age { get; set; }
        public string BirthDate { get; set; }   
        public Cicle MyCicle { get; set; }
        public int AverageScore { get; set; }
        public bool Dual { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }

        public List<String> Hobbies { get; set; }


        //public Student(string name, string surname, int age, Cicle c, int avgScore, bool dual, string id, List<String> hobbies) 
        //{
        //    this.Name = name;
        //    this.Surname = surname;
        //    this.Age = age;
        //    this.MyCicle = c;
        //    this.AverageScore = avgScore;
        //    this.Id = id;
        //    this.Hobbies = hobbies;
        //}
        public Student()
        {

        }


        public override string ToString()
        {
            return $"Student: {Name} {Surname}";
        }
    }
}
