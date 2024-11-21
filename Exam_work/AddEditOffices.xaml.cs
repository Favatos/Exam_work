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
    /// Логика взаимодействия для AddEditOffices.xaml
    /// </summary>
    public partial class AddEditOffices : Window
    {
        public AddEditOffices(Office office)
        {
            InitializeComponent();
            DataContext = new Office() { Name = office.Name, Department = office.Department };
            string json = File.ReadAllText("departments.json");
            comboBox.ItemsSource = JsonSerializer.Deserialize<ObservableCollection<Department>>(json);
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
