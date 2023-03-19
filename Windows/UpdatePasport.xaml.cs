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
    /// Логика взаимодействия для UpdatePasport.xaml
    /// </summary>
    public partial class UpdatePasport : Window
    {
        public MainWindow mainWindow;
        int globalPasIndex = -1;
        public UpdatePasport(MainWindow _mainWindow, int index)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            globalPasIndex = index;
            name.Text = mainWindow.passports[globalPasIndex].name;
            first_name.Text = mainWindow.passports[globalPasIndex].first_name;
            last_name.Text = mainWindow.passports[globalPasIndex].last_name;
            issued.Text = mainWindow.passports[globalPasIndex].issued;
            date_of_issue.Text = mainWindow.passports[globalPasIndex].date_of_issue;
            departament_code.Text = mainWindow.passports[globalPasIndex].departament_code;
            series_and_number.Text = mainWindow.passports[globalPasIndex].series_and_number;
            date_of_birth.Text = mainWindow.passports[globalPasIndex].date_of_birth;
            place_of_birth.Text = mainWindow.passports[globalPasIndex].place_of_birth;
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {               
                if (AddAndUpdateTextBoxCheck.TextBoxCheck(name, first_name, last_name, issued, date_of_issue, departament_code,
                    series_and_number, date_of_birth, place_of_birth))
                {
                    mainWindow.passports[globalPasIndex].name = name.Text;
                    mainWindow.passports[globalPasIndex].first_name = first_name.Text;
                    mainWindow.passports[globalPasIndex].last_name = last_name.Text;
                    mainWindow.passports[globalPasIndex].issued = issued.Text;
                    mainWindow.passports[globalPasIndex].date_of_issue = date_of_issue.Text;
                    mainWindow.passports[globalPasIndex].departament_code = departament_code.Text;
                    mainWindow.passports[globalPasIndex].series_and_number = series_and_number.Text;
                    mainWindow.passports[globalPasIndex].date_of_birth = date_of_birth.Text;
                    mainWindow.passports[globalPasIndex].place_of_birth = place_of_birth.Text;
                    Close();
                }
            }
            catch
            {

            }
        }
    }
}
