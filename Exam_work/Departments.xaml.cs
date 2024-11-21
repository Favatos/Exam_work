using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    public partial class Departments : Window
    {
        IList<Department> Departments_ { get; } = new ObservableCollection<Department>();
        public Departments()
        {
            InitializeComponent();
            if (File.Exists("departments.json"))
            {
                string json = File.ReadAllText("departments.json");
                Departments_ = JsonSerializer.Deserialize<ObservableCollection<Department>>(json);
            }
            DataContext = Departments_;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditDepartment addEdit = new(new Department());
            if(addEdit.ShowDialog() == true)
            {
                Departments_.Add((Department)addEdit.DataContext);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            AddEditDepartment addEdit = new(Departments_[listView.SelectedIndex]);
            if (addEdit.ShowDialog() == true)
            {
                Departments_[listView.SelectedIndex] = (Department)addEdit.DataContext;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            Departments_.RemoveAt(listView.SelectedIndex);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string file = JsonSerializer.Serialize(Departments_);
            File.WriteAllText("departments.json", file);

            DialogResult = true;
        }
    }
}
