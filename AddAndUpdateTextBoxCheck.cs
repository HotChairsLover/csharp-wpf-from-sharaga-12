using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Passport_Office
{
    class AddAndUpdateTextBoxCheck
    {
        public static bool TextBoxCheck(TextBox name, TextBox first_name, TextBox last_name, TextBox issued, TextBox date_of_issue, TextBox departament_code, 
            TextBox series_and_number, TextBox date_of_birth, TextBox place_of_birth)
        {
            bool isError = false;
            try
            {
                if (name.Text != "" && first_name.Text != "" && last_name.Text != "" && issued.Text != "" && date_of_issue.Text != ""
                    && departament_code.Text != "" && series_and_number.Text != "" && date_of_birth.Text != "" && place_of_birth.Text != "")
                {
                    for (int i = 0; i < name.Text.Length; i++)
                    {
                        if (!char.IsLetter(name.Text[i]))
                        {
                            isError = true;
                            MessageBox.Show("В имени должны содержаться только буквы");
                            break;
                        }
                    }
                    for (int i = 0; i < first_name.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        else if (!char.IsLetter(first_name.Text[i]))
                        {
                            isError = true;
                            MessageBox.Show("В фамилии должны содержаться только буквы");
                            break;
                        }
                    }
                    for (int i = 0; i < last_name.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        else if (!char.IsLetter(last_name.Text[i]))
                        {
                            isError = true;
                            MessageBox.Show("В отчестве должны содержаться только буквы");
                            break;
                        }
                    }
                    for (int i = 0; i < issued.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        else if (!char.IsLetter(issued.Text[i]))
                        {
                            isError = true;
                            MessageBox.Show("В месте выдачи должны содержаться только буквы");
                            break;
                        }
                    }
                    for (int i = 0; i < date_of_issue.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        try
                        {
                            DateTime date = Convert.ToDateTime(date_of_issue.Text);
                            if(date > DateTime.Today)
                            {
                                isError = true;
                                MessageBox.Show("Дата выдачи не может быть больше сегодняшней");
                            }
                        }
                        catch
                        {
                            isError = true;
                            MessageBox.Show("Дата выдачи должна быть записана в формате 01.01.1990");
                            break;
                        }                                         
                    }
                    for (int i = 0; i < departament_code.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        else if(departament_code.Text.Length != 7 || !departament_code.Text.Contains('-'))
                        {
                            isError = true;
                            MessageBox.Show("Код подразделения должен быть записан в формате XXX-XXX");
                            break;
                        }
                        else if (!char.IsDigit(departament_code.Text[i]) & departament_code.Text[i] != '-')
                        {
                            isError = true;
                            MessageBox.Show("В коде подразделения должны быть только цифры");
                            break;
                        }
                    }
                    for (int i = 0; i < series_and_number.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        else if(series_and_number.Text.Length != 12 || !series_and_number.Text.Contains(' '))
                        {
                            isError = true;
                            MessageBox.Show("Серия и номер паспорта должны быть записаны в формате СС СС НННННН");
                            break;
                        }                       
                        else if (!char.IsDigit(series_and_number.Text[i]) & series_and_number.Text[i] != ' ')
                        {
                            isError = true;
                            MessageBox.Show("В серии и номера должны быть только цифры");
                            break;
                        }
                        string[] series_and_number_split = series_and_number.Text.Trim().Split(' ');
                        if(series_and_number_split.Length != 3 || series_and_number_split[0].Length != 2 || 
                            series_and_number_split[1].Length != 2 || series_and_number_split[2].Length != 6)
                        {
                            isError = true;
                            MessageBox.Show("Серия и номер паспорта должны быть записаны в формате СС СС НННННН");
                            break;
                        }
                    }
                    for (int i = 0; i < date_of_birth.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        try
                        {
                            DateTime date = Convert.ToDateTime(date_of_birth.Text);
                            if (date > DateTime.Today)
                            {
                                isError = true;
                                MessageBox.Show("Дата рождения не может быть больше сегодняшней");
                            }
                        }
                        catch
                        {
                            isError = true;
                            MessageBox.Show("Дата рождения должна быть записана в формате 01.01.1990");
                            break;
                        }
                    }
                    for (int i = 0; i < place_of_birth.Text.Length; i++)
                    {
                        if (isError)
                        {
                            break;
                        }
                        else if (!char.IsLetter(place_of_birth.Text[i]))
                        {
                            isError = true;
                            MessageBox.Show("В месте рождения должны содержаться только буквы");
                            break;
                        }
                    }
                    if (!isError)
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
            }
            catch
            {

            }
            return false;
        }
    }
}
