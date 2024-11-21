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
    /// Логика взаимодействия для Positions.xaml
    /// </summary>
    public partial class Positions : Window
    {
        public IList<Position> Positions_ {  get; set; } = new ObservableCollection<Position>();
        public Positions()
        {
            InitializeComponent();
            if (File.Exists("positions.json"))
            {
                string json = File.ReadAllText("positions.json");
                Positions_ = JsonSerializer.Deserialize<ObservableCollection<Position>>(json);
            }
            DataContext = Positions_;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditPosition add = new(new Position());
            if (add.ShowDialog() == true)
            {
                Positions_.Add((Position)add.DataContext);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            AddEditPosition add = new(Positions_[listView.SelectedIndex]);
            if (add.ShowDialog() == true)
            {
                Positions_[listView.SelectedIndex] = (Position)add.DataContext;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null) return;
            Positions_.RemoveAt(listView.SelectedIndex);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string file = JsonSerializer.Serialize(Positions_);
            File.WriteAllText("positions.json", file);

            DialogResult = true;
        }
    }
}
