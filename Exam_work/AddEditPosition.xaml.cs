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

namespace Exam_work
{
    /// <summary>
    /// Логика взаимодействия для AddEditPosition.xaml
    /// </summary>
    public partial class AddEditPosition : Window
    {
        public AddEditPosition(Position position)
        {
            InitializeComponent();
            DataContext = new Position(position.Name, position.Salary);
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
