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

namespace Passport_Office
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int globalPasIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Passport
        {
            public string name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string issued { get; set; }
            public string date_of_issue { get; set; }
            public string departament_code { get; set; }
            public string series_and_number { get; set; }
            public string date_of_birth { get; set; }
            public string place_of_birth { get; set; }
        }

        public List<Passport> passports = new List<Passport>();

        public void LoadPassports()
        {
            lv_pasports.Items.Clear();

            for(int i = 0; i < passports.Count; i++)
            {
                lv_pasports.Items.Add(passports[i]);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            new Windows.AddPasport(this).ShowDialog();

            LoadPassports();
        }

        private bool DeleteAndUpdateSupport()
        {
            bool isError = false;
            bool isComplete = false;
            if (findPassTextBox.Text != "")
            {
                for (int i = 0; i < findPassTextBox.Text.Length; i++)
                {
                    if (!char.IsDigit(findPassTextBox.Text[i]) & findPassTextBox.Text[i] != ' ')
                    {
                        isError = true;
                        MessageBox.Show("В серии и номере должны быть только цифры");
                        break;
                    }
                }
                if (!isError)
                {
                    for (int passIndex = 0; passIndex < passports.Count; passIndex++)
                    {
                        if (passports[passIndex].series_and_number == findPassTextBox.Text)
                        {
                            globalPasIndex = passIndex;
                            isComplete = true;
                            return true;
                        }
                    }
                    
                }
                if (!isComplete)
                {
                    MessageBox.Show(String.Format("Паспорта с номером {0} не существует", findPassTextBox.Text));
                }
            }
            else
            {
                MessageBox.Show("Введите серию и номер паспорта");
            }
            return false;

        }
        private void Update(object sender, RoutedEventArgs e)
        {    
            if (DeleteAndUpdateSupport())
            {
                new Windows.UpdatePasport(this, globalPasIndex).ShowDialog();

                LoadPassports();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (DeleteAndUpdateSupport())
            {
                passports.RemoveAt(globalPasIndex);
                LoadPassports();
                MessageBox.Show(String.Format("Паспорт с номером {0} успешно удален!", findPassTextBox.Text));
            }
        }
        public void FindPassports(string[] text)
        {
            lv_pasports.Items.Clear();
            for (int i = 0; i < passports.Count; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (text.Length == 1)
                    {
                        if (passports[i].name == text[j] || passports[i].first_name == text[j] || passports[i].last_name == text[j])
                        {
                            lv_pasports.Items.Add(passports[i]);
                        }
                    }
                    else if (text.Length == 2)
                    {
                        if ((passports[i].name == text[j] && passports[i].first_name == text[j + 1]) || (passports[i].name == text[j] && passports[i].last_name == text[j + 1])
                            || (passports[i].first_name == text[j] && passports[i].last_name == text[j + 1]))
                        {
                            lv_pasports.Items.Add(passports[i]);
                        }
                    }
                    else if (text.Length == 3)
                    {
                        if (passports[i].name == text[j] && passports[i].first_name == text[j+1] && passports[i].last_name == text[j+2])
                        {
                            lv_pasports.Items.Add(passports[i]);
                        }
                    }
                }
            }
        }

        private void FindPass(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                FindPassports(findPassTextBox.Text.Split(' '));
            }
        }
    }
}
