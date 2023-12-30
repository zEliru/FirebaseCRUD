using Fire.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Data_Access.Repositories
{
    public class FirebaseRepository : IFirebaseRepository
    {
        //private string _url = "https://test-b2be1-default-rtdb.europe-west1.firebasedatabase.app/\r\n:\r\nnull\r\n";
        private string _url = "https://students-b1280-default-rtdb.europe-west1.firebasedatabase.app/";

        private string _secret = "rkNghJmP3TGt6nQYHcDAsURdEXWTMjGU6NTxf94S";
        FirebaseClient firebaseClient;
        /// <summary>
        /// estableix la connexió amb la realtime Database fent una crida a la classe
        /// FirebaseConnection.GetFireBaseClient(url, secret) al seu constructor.
        /// </summary>
        public FirebaseRepository() 
        {
            firebaseClient = FirebaseConnection.GetFirebaseClient(_url, _secret);
        }
        /// <summary>
        /// Exemple copiat del PDF1 (NoSQL..)
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddStudent(Student student)
        {
            bool completed = false;
            bool exists = true;
            try
            {
                exists = await ExistsStudent(student.FullName);
                if (exists) throw new Exception("Student already exists");
                // "else"
                await firebaseClient
                .Child("Students")
                .Child(student.FullName)
                .PostAsync(student);
                completed = true;
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return completed;
        }
        /// <summary>
        /// Exemple copiat de l'enunciat de la pràctica
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> ExistsStudent(string name)
        {
            try
            {
                return await firebaseClient
               .Child("Students")
               .Child($"{name}")
               .OnceSingleAsync<Student>() != null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
            return false;

        }

        public async Task<Student> GetStudent(string name)
        {

            Student st = new Student();
            try
            {
                st = await firebaseClient
              .Child("Students")
              .Child($"{name}")
              .OnceSingleAsync<Student>();
                if (st == null) throw new Exception("Coulnd't find student");

                st.Name = name.Split(' ')[0];
                st.Surname = name.Split(' ')[1];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           



            return st;
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents()
        {
            try
            {
                var students = await firebaseClient
                .Child("Students")
                .OnceAsync<Student>();

                foreach (var std in students)
                {
                    std.Object.Name = std.Key.Split(' ')[0];
                    std.Object.Surname = std.Key.Split(' ')[1];
                }

                //students.Select(
                //    firebaseObject =>
                //    {
                //        var std = firebaseObject.Key;
                //        firebaseObject.Object.Name = std.Split(' ')[0];
                //        firebaseObject.Object.Surname = std.Split(' ')[1];

                //        return firebaseObject;
                //    }

                //    );


                return students;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }

            // this will never happen please forgive me for I have sinned
            return null;

        }

        public async Task<bool> RemoveStudent(string student)
        {
            try
            {
                await firebaseClient
                                .Child("Students")
                                .Child(student)
                                .DeleteAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
