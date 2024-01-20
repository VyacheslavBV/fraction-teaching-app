using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static System.Net.Mime.MediaTypeNames;

namespace Обучающее_приложение_Дроби
{
    
    public partial class MainWindow : Window
    {
        private void rets(object sender, RoutedEventArgs e)
        {
            bool flagtrans1 = false;
            bool flagtrans2 = false;
            bool flagstart = false;

            ANS1.Text = "";
            ANS2.Text = "";
            ANS3.Text = "";
            ANS4.Text = "";

            answer1.Text = "";
            answer2.Text = "";
            answer3.Text = "";
            answer4.Text = "";
            answer5.Text = "";
            answer6.Text = "";
            answer7.Text = "";
            answer8.Text = "";
            answer9.Text = "";
            answer10.Text = "";
            answer11.Text = "";
            answer12.Text = "";

            Error.Text = "Ошибок нет.";

            if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
            {
                Error.Text = "Ошибка: Не все поля заполнены!";
            }

            else
            {
                if (String.IsNullOrEmpty(sign.Text) && sign.Text != "+" && sign.Text != "*" && sign.Text != "/" && sign.Text != "-")
                {
                    Error.Text = "Значение в поле знака отсутствует или некорректно";
                }

                else
                {

                    flagstart = true;
                }


                if (flagstart == true)
                {
                    int.TryParse(textBox3.Text, out int up1);
                    int.TryParse(textBox6.Text, out int up2);
                    int.TryParse(textBox2.Text, out int down1);
                    int.TryParse(textBox5.Text, out int down2);

                    if (down1 == 0 || down2 == 0)
                    {
                        ANS4.Text = "∞";
                    }
                    else
                    {

                        int upanswer = 0;
                        int downanswer = 0;


                        if (!String.IsNullOrEmpty(textBox1.Text))
                        {
                            if (int.TryParse(textBox1.Text, out _))
                            {
                                flagtrans1 = true;
                            }
                            else
                            {
                                Error.Text = "Поле целой части первой дроби заполнено некорректно";
                            }
                        }

                        if (!String.IsNullOrEmpty(textBox4.Text))
                        {
                            if (int.TryParse(textBox4.Text, out _))
                            {
                                flagtrans2 = true;
                            }
                            else
                            {
                                Error.Text = "Поле целой части второй дроби заполнено некорректно";
                            }
                        }




                        if (flagtrans1 == true)
                        {
                            int.TryParse(textBox1.Text, out int value1);
                            int.TryParse(textBox2.Text, out int value2);
                            int.TryParse(textBox3.Text, out int value3);

                            answer1.Text = "Перевод первой смешанной дроби:";
                            answer2.Text = $"Числитель: {textBox1.Text} * {textBox2.Text} + {textBox3.Text} = {value1 * value2 + value3}";
                            up1 = value1 * value2 + value3;
                        }

                        if (flagtrans2 == true)
                        {
                            int.TryParse(textBox4.Text, out int value4);
                            int.TryParse(textBox5.Text, out int value5);
                            int.TryParse(textBox6.Text, out int value6);

                            answer3.Text = "Перевод второй смешанной дроби:";
                            answer4.Text = $"Числитель: {textBox4.Text} * {textBox5.Text} + {textBox6.Text} = {value4 * value5 + value6}";
                            up2 = value4 * value5 + value6;
                        }

                        if (sign.Text == "+")
                        {
                            answer5.Text = "Сложение: ";
                            answer6.Text = $"Числитель: {up1} * {down2} + {up2} * {down1} = {up1 * down2 + up2 * down1}";
                            answer7.Text = $"Знаменатель: {down1} * {down2} = {down1 * down2}";
                            upanswer = up1 * down2 + up2 * down1;
                            downanswer = down1 * down2;
                        }

                        else if (sign.Text == "-")
                        {
                            answer5.Text = "Вычитание: ";
                            answer6.Text = $"Числитель: {up1} * {down2} - {up2} * {down1} = {up1 * down2 - up2 * down1}";
                            answer7.Text = $"Знаменатель: {down1} * {down2} = {down1 * down2}";
                            upanswer = up1 * down2 - up2 * down1;
                            downanswer = down1 * down2;
                        }

                        else if (sign.Text == "/")
                        {
                            answer5.Text = "Деление: ";
                            answer6.Text = $"Числитель: {up1} * {down2} = {up1 * down2}";
                            answer7.Text = $"Знаменатель: {up2} * {down1} = {up2 * down1}";
                            upanswer = up1 * down2;
                            downanswer = up2 * down1;
                        }

                        else if (sign.Text == "*")
                        {
                            answer5.Text = "Умножение: ";
                            answer6.Text = $"Числитель: {up1} * {down1} = {up1 * down1}";
                            answer7.Text = $"Знаменатель: {up2} * {down2} = {up2 * down2}";
                            upanswer = up1 * down1;
                            downanswer = up2 * down1;
                        }

                        if (downanswer != 0)
                        {
                            int i = 2;
                            string str = "Простые общие множители: ";
                            bool flagfirst = true;
                            double dupanswer = Math.Abs(upanswer);
                            double ddownanswer = Math.Abs(downanswer);
                            char flagminus = 'F';

                            if (upanswer < 0 && downanswer < 0)
                            {
                                flagminus = 'F';
                            }
                            else if (upanswer > 0 && downanswer < 0)
                            {
                                flagminus = 'T';
                            }
                            else if (upanswer < 0 && downanswer > 0)
                            {
                                flagminus = 'T';
                            }
                            else
                            {
                                flagminus = 'F';
                            }

                            while (i < Math.Abs(upanswer) + 1)
                            {
                                if (dupanswer % i == 0 && ddownanswer % i == 0)
                                {
                                    if (flagfirst == false)
                                    {
                                        str += ", ";
                                    }

                                    str += $"{i}";
                                    dupanswer /= i;
                                    ddownanswer /= i;

                                    if (flagfirst == true)
                                    {
                                        flagfirst = false;
                                    }
                                }

                                else
                                {
                                    i += 1;
                                }
                            }


                            int cnt = 0;

                            for (int j = 0; j < ddownanswer; j++)
                            {
                                if (ddownanswer == 1)
                                {
                                    break;
                                }

                                if ((ddownanswer < dupanswer) && ((dupanswer - ddownanswer) > 0))
                                {
                                    cnt += 1;
                                    dupanswer -= ddownanswer;
                                }
                                
                                else
                                {
                                    
                                    break;
                                }
                            }
                            
                            

                            if (flagfirst == true && (dupanswer == 0 || ddownanswer == 0))
                            {
                                ANS4.Text = "0";
                            }

                            else if (flagfirst == true)
                            {

                                if (cnt != 0)
                                {
                                    answer11.Text = $"Выделим целую часть: Вычитаем из числителя занаменатель до тех пор, ";
                                    answer12.Text = $"пока тот не станет меньше или равен последнему. Результат {cnt}";
                                    ANS4.Text = $"{cnt}";
                                }

                                ANS1.Text = "--------";
                                ANS2.Text = $"{ddownanswer}";

                                if (flagminus == 'T')
                                {
                                    ANS3.Text = $"-{dupanswer}";
                                }
                                else
                                {
                                    ANS3.Text = $"{dupanswer}";
                                }

                            }

                            else
                            {
                                if (cnt != 0)
                                {
                                    answer11.Text = $"Выделим целую часть: Вычитаем из числителя занаменатель до тех пор, ";
                                    answer12.Text = $"пока тот не станет меньше или равен последнему. Результат {cnt}";
                                    ANS4.Text = $"{cnt}";
                                }

                                answer8.Text = "Упрощаем ответ:";
                                answer9.Text = str;
                                answer10.Text = "Сократим на них числитель и знаменатель и получим ответ";

                                ANS1.Text = "--------";
                                ANS2.Text = $"{ddownanswer}";

                                if (flagminus == 'T')
                                {
                                    ANS3.Text = $"-{dupanswer}";
                                }
                                else
                                {
                                    ANS3.Text = $"{dupanswer}";
                                }
                            }
                        }
                    }
                }
            }
        }




        private void del(object sender, RoutedEventArgs e)
        {
            ANS1.Text = "";
            ANS2.Text = "";
            ANS3.Text = "";
            ANS4.Text = "";

            answer1.Text = "";
            answer2.Text = "";
            answer3.Text = "";
            answer4.Text = "";
            answer5.Text = "";
            answer6.Text = "";
            answer7.Text = "";
            answer8.Text = "";
            answer9.Text = "";
            answer10.Text = "";
            answer11.Text = "";
            answer12.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            sign.Text = "";

            Error.Text = "Ошибок нет.";
        }

        private void ret(object sender, RoutedEventArgs e)
        {
            bool flagtrans1 = false;
            bool flagtrans2 = false;
            bool flagstart = false;

            ANS1.Text = "";
            ANS2.Text = "";
            ANS3.Text = "";
            ANS4.Text = "";

            answer1.Text = "";
            answer2.Text = "";
            answer3.Text = "";
            answer4.Text = "";
            answer5.Text = "";
            answer6.Text = "";
            answer7.Text = "";
            answer8.Text = "";
            answer9.Text = "";
            answer10.Text = "";
            answer11.Text = "";
            answer12.Text = "";

            Error.Text = "Ошибок нет.";

            if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
            {
                Error.Text = "Ошибка: Не все поля заполнены!";
            }

            else
            {
                if (String.IsNullOrEmpty(sign.Text) && sign.Text != "+" && sign.Text != "*" && sign.Text != "/" && sign.Text != "-")
                {
                    Error.Text = "Значение в поле знака отсутствует или некорректно";
                }

                else
                {
                    
                    flagstart = true;
                }


                if (flagstart == true)
                {
                    int.TryParse(textBox3.Text, out int up1);
                    int.TryParse(textBox6.Text, out int up2);
                    int.TryParse(textBox2.Text, out int down1);
                    int.TryParse(textBox5.Text, out int down2);

                    if (down1 == 0 || down2 == 0)
                    {
                        ANS4.Text = "∞";
                    }
                    else { 

                        int upanswer = 0;
                        int downanswer = 0;


                        if (!String.IsNullOrEmpty(textBox1.Text))
                        {
                            if (int.TryParse(textBox1.Text, out _))
                            {
                                flagtrans1 = true;
                            }
                            else
                            {
                                Error.Text = "Поле целой части первой дроби заполнено некорректно";
                            }
                        }

                        if (!String.IsNullOrEmpty(textBox4.Text))
                        {
                            if (int.TryParse(textBox4.Text, out _))
                            {
                                flagtrans2 = true;
                            }
                            else
                            {
                                Error.Text = "Поле целой части второй дроби заполнено некорректно";
                            }
                        }




                        if (flagtrans1 == true)
                        {
                            int.TryParse(textBox1.Text, out int value1);
                            int.TryParse(textBox2.Text, out int value2);
                            int.TryParse(textBox3.Text, out int value3);

                            answer1.Text = "Перевод первой смешанной дроби:";
                            answer2.Text = $"Числитель: {textBox1.Text} * {textBox2.Text} + {textBox3.Text} = {value1 * value2 + value3}";
                            up1 = value1 * value2 + value3;
                        }
                    
                        if (flagtrans2 == true)
                        {
                            int.TryParse(textBox4.Text, out int value4);
                            int.TryParse(textBox5.Text, out int value5);
                            int.TryParse(textBox6.Text, out int value6);

                            answer3.Text = "Перевод второй смешанной дроби:";
                            answer4.Text = $"Числитель: {textBox4.Text} * {textBox5.Text} + {textBox6.Text} = {value4 * value5 + value6}";
                            up2 = value4 * value5 + value6;
                        }

                        if (sign.Text == "+")
                        {
                            answer5.Text = "Сложение: ";
                            answer6.Text = $"Числитель: {up1} * {down2} + {up2} * {down1} = {up1 * down2 + up2 * down1}";
                            answer7.Text = $"Знаменатель: {down1} * {down2} = {down1 * down2}";
                            upanswer = up1 * down2 + up2 * down1;
                            downanswer = down1 * down2;
                        }

                        else if (sign.Text == "-")
                        {
                            answer5.Text = "Вычитание: ";
                            answer6.Text = $"Числитель: {up1} * {down2} - {up2} * {down1} = {up1 * down2 - up2 * down1}";
                            answer7.Text = $"Знаменатель: {down1} * {down2} = {down1 * down2}";
                            upanswer = up1 * down2 - up2 * down1;
                            downanswer = down1 * down2;
                        }

                        else if (sign.Text == "/")
                        {
                            answer5.Text = "Деление: ";
                            answer6.Text = $"Числитель: {up1} * {down2} = {up1 * down2}";
                            answer7.Text = $"Знаменатель: {up2} * {down1} = {up2 * down1}";
                            upanswer = up1 * down2;
                            downanswer = up2 * down1;
                        }

                        else if (sign.Text == "*")
                        {
                            answer5.Text = "Умножение: ";
                            answer6.Text = $"Числитель: {up1} * {down1} = {up1 * down1}";
                            answer7.Text = $"Знаменатель: {up2} * {down2} = {up2 * down2}";
                            upanswer = up1 * down1;
                            downanswer = up2 * down1;
                        }

                        if (downanswer != 0)
                        {
                            int i = 2;
                            string str = "Простые общие множители: ";
                            bool flagfirst = true;
                            double dupanswer = Math.Abs(upanswer);
                            double ddownanswer = Math.Abs(downanswer);
                            char flagminus = 'F';

                            if (upanswer < 0 && downanswer < 0)
                            {
                                flagminus = 'F';
                            }
                            else if (upanswer > 0 && downanswer < 0)
                            {
                                flagminus = 'T';
                            }
                            else if (upanswer < 0 && downanswer > 0)
                            {
                                flagminus = 'T';
                            }
                            else
                            {
                                flagminus = 'F';
                            }

                            while (i < Math.Abs(upanswer) + 1)
                            {
                                if (dupanswer % i == 0 && ddownanswer % i == 0)
                                {
                                    if (flagfirst == false)
                                    {
                                        str += ", ";
                                    }

                                    str += $"{i}";
                                    dupanswer /= i;
                                    ddownanswer /= i;

                                    if (flagfirst == true)
                                    {
                                        flagfirst = false;
                                    }
                                }

                                else
                                {
                                    i += 1;
                                }
                            }

                            if (flagfirst == true && (dupanswer == 0 || ddownanswer == 0))
                            {
                                ANS4.Text = "0";
                            }
                            
                            else if (flagfirst == true)
                            {
                                ANS1.Text = "--------";
                                ANS2.Text = $"{ddownanswer}";

                                if (flagminus == 'T')
                                {
                                    ANS3.Text = $"-{dupanswer}";
                                }
                                else
                                {
                                    ANS3.Text = $"{dupanswer}";
                                }

                            }

                            else
                            {
                                answer8.Text = "Упрощаем ответ:";
                                answer9.Text = str;
                                answer10.Text = "Сократим на них числитель и знаменатель и получим ответ";

                                ANS1.Text = "--------";
                                ANS2.Text = $"{ddownanswer}";

                                if (flagminus == 'T')
                                {
                                    ANS3.Text = $"-{dupanswer}";
                                }
                                else
                                {
                                    ANS3.Text = $"{dupanswer}";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
