using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exam_work
{
    public partial class AddEditStaff : Window
    {
        public AddEditStaff(Employee employee)
        {
            InitializeComponent();
            DataContext = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Name = employee.Name,
                Department = employee.Department,
                Office = employee.Office,
                Post = employee.Post
            };
            string json1 = File.ReadAllText("departments.json");
            string json2 = File.ReadAllText("positions.json");
            string json3 = File.ReadAllText("offices.json");
            comboDepartment.ItemsSource = JsonSerializer.Deserialize<ObservableCollection<Department>>(json1);
            comboPost.ItemsSource = JsonSerializer.Deserialize<ObservableCollection<Position>>(json2);
            comboOffice.ItemsSource = JsonSerializer.Deserialize<ObservableCollection<Office>>(json3);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
