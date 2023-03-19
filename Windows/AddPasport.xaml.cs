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

namespace Passport_Office.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPasport.xaml
    /// </summary>
    public partial class AddPasport : Window
    {
        public MainWindow mainWindow;
        public AddPasport(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddAndUpdateTextBoxCheck.TextBoxCheck(name, first_name, last_name, issued, date_of_issue, departament_code,
                    series_and_number, date_of_birth, place_of_birth))
                {
                    MainWindow.Passport new_passport = new MainWindow.Passport();
                    new_passport.name = name.Text;
                    new_passport.first_name = first_name.Text;
                    new_passport.last_name = last_name.Text;
                    new_passport.issued = issued.Text;
                    new_passport.date_of_issue = date_of_issue.Text;
                    new_passport.departament_code = departament_code.Text;
                    new_passport.series_and_number = series_and_number.Text;
                    new_passport.date_of_birth = date_of_birth.Text;
                    new_passport.place_of_birth = place_of_birth.Text;
                    mainWindow.passports.Add(new_passport);
                    Close();
                }
            }
            catch
            {

            }
        }
    }
}
