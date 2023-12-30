using Fire.Data_Access.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fire.Models;
using Fire.Domain;
using Fire.Views;

namespace Fire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IFirebaseDomain fr;
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                fr = FirebaseDomainFactory.CreateFirebaseDomain();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadForm();

        }
        public void LoadForm()
        {

        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Cicle c = new Cicle(tbCicle.Text.ToString());
                //Student s = new Student(tbName.Text.ToString(), tbSurname.Text.ToString(), Convert.ToInt32(tbAge.Text.ToString()), c);

                Student s = new Student
                {
                    Name = tbName.Text,
                    Surname = tbSurname.Text,
                    Age = Convert.ToInt32(tbAge.Text),
                   
                };
                fr.AddStudent(s);
                MessageBox.Show("Created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Student s = await fr.GetStudent($"{tbName.Text} {tbSurname.Text}");
            if (s is null)
            {
                MessageBox.Show("Couldn't find student");
            }
            else
            {
                string hobbies = "";
                if (s.Hobbies != null)
                    foreach (String str in s.Hobbies) hobbies = hobbies + " " + str;
                MessageBox.Show($"{s.ToString()}, his ID: {s.Id}, Hobbies: {hobbies}");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fr.RemoveStudent(tbName.Text +  " " + tbSurname.Text);
                MessageBox.Show($"Deleted {tbName.Text} {tbSurname.Text}");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void btnListAll_Click(object sender, RoutedEventArgs e)
        {
            List<Student> sts = await fr.GetListStudents();
            AllStudents allst = new AllStudents(sts);
            allst.Show();
        }
    }
}
