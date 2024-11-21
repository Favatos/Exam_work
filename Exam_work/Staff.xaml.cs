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
    /// <summary>
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class StaffClass : Window
    {
        public IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public StaffClass()
        {
            InitializeComponent();
            if (File.Exists("employees.json"))
            {
                string json = File.ReadAllText("employees.json");
                Employees = JsonSerializer.Deserialize<ObservableCollection<Employee>>(json);
            }
            DataContext = Employees;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("departments.json") == false || File.Exists("positions.json") == false || File.Exists("offices.json") == false)
            {
                MessageBox.Show(" You do not have any departments/positions/offices yet. Please add them via the buttons in the main menu", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            AddEditStaff addEdit = new(new Employee());
            if (addEdit.ShowDialog() == true)
            {
                Employees.Add((Employee)addEdit.DataContext);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("departments.json") == false || File.Exists("positions.json") == false || File.Exists("offices.json") == false)
            {
                MessageBox.Show(" You do not have any departments/positions/offices yet. Please add them via the buttons in the main menu", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (listView.SelectedItem == null) return;
            AddEditStaff addEdit = new(Employees[listView.SelectedIndex]);
            if (addEdit.ShowDialog() == true)
            {
                Employees[listView.SelectedIndex] = (Employee)addEdit.DataContext;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            Employees.RemoveAt(listView.SelectedIndex);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string file = JsonSerializer.Serialize(Employees);
            File.WriteAllText("employees.json", file);

            DialogResult = true;
        }
    }
}
