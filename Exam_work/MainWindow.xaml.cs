using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam_work
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffClass staff = new StaffClass();
            staff.ShowDialog();
        }

        private void ButtonDepartments_Click(object sender, RoutedEventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void ButtonPositions_Click(object sender, RoutedEventArgs e)
        {
            Positions positions = new Positions();
            positions.ShowDialog();
        }

        private void ButtonOffices_Click(object sender, RoutedEventArgs e)
        {
            Offices offices = new Offices();
            offices.ShowDialog();
        }
    }
}