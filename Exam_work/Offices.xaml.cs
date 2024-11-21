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
    /// Логика взаимодействия для Offices.xaml
    /// </summary>
    public partial class Offices : Window
    {
        public IList<Office> Offices_ {  get; set; } = new ObservableCollection<Office>();
        public Offices()
        {
            InitializeComponent();
            if (File.Exists("offices.json"))
            {
                string json = File.ReadAllText("offices.json");
                Offices_ = JsonSerializer.Deserialize<ObservableCollection<Office>>(json);
            }
            DataContext = Offices_;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditOffices addEdit = new(new Office());
            if  (addEdit.ShowDialog() == true)
            {
                Offices_.Add((Office)addEdit.DataContext);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            AddEditOffices addEdit = new(Offices_[listView.SelectedIndex]);
            if (addEdit.ShowDialog() == true)
            {
                Offices_[listView.SelectedIndex] = (Office)addEdit.DataContext;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            Offices_.RemoveAt(listView.SelectedIndex);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string file = JsonSerializer.Serialize(Offices_);
            File.WriteAllText("offices.json", file);

            DialogResult = true;
        }
    }
}
