using _20._101_Titaeva_2.Entity;
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
using _20._101_Titaeva_2.Entity;

namespace _20._101_Titaeva_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities m = new Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void UpdateData()
        {
            var result = Entities.GetContex().Product.ToList();//вводим переменную, которвя принимает данные из таблицы товаров
            result = result.Where(p => p.ProductName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            Teachers_dg.ItemsSource = result;
        }

        private void Teacher_Loaded(object sender, RoutedEventArgs e)
        {
            //подключение данных к датагрид
            var query1 = from teachers in m.Teachers select new { teachers.IdTeachers, teachers.LastName, teachers.FirstName, teachers.Patronymic, teachers.Email, teachers.IdStatusTeachers, teachers.IdRole, teachers.IdSpeciality, teachers.Attestation, teachers.DisciplineTeachers, teachers.Role, teachers.Speciality, teachers.StatusTeacher, teachers.SystemUser};
            Teachers_dg.ItemsSource = query1.ToList(); //вывод информации
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
