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
using System.Windows.Shapes;
using Fire.Models;

namespace Fire.Views
{
    /// <summary>
    /// Lógica de interacción para AllStudents.xaml
    /// </summary>
    public partial class AllStudents : Window
    {
        List<Student> data = new List<Student>();
        public AllStudents(List<Student> st)
        {
            InitializeComponent();
            data = st;
            datagridStudents.ItemsSource = data;




        }
    }
}
