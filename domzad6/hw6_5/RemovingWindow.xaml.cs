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

namespace hw6_5
{
    /// <summary>
    /// Логика взаимодействия для RemovingWindow.xaml
    /// </summary>
    public partial class RemovingWindow : Window
    {
        public RemovingWindow()
        {
            InitializeComponent();
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        public int remnum;
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //int[] maxnums = { MainWindow.circlescount, MainWindow.rectanglescount, MainWindow.trapezoidscount };
            //maxnums = { MainWindow.circlescount; MainWindow.rectanglescount; MainWindow.trapezoidscount };

            switch (selectbox.SelectedIndex)
            {
                case 0:
                    try
                    {
                        remnum = int.Parse(rembox.Text);
                        if (remnum > MainWindow.circlescount || remnum < 1) throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(String.Format("Укажите номер записи от 1 до {0}", MainWindow.circlescount));
                        return;
                    }
                    break;
                case 1:
                    try
                    {
                        remnum = int.Parse(rembox.Text);
                        if (remnum > MainWindow.rectanglescount || remnum < 1) throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(String.Format("Укажите номер записи от 1 до {0}", MainWindow.rectanglescount));
                        return;
                    }
                    break;
                case 2:
                    try
                    {
                        remnum = int.Parse(rembox.Text);
                        if (remnum > MainWindow.trapezoidscount || remnum < 1) throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(String.Format("Укажите номер записи от 1 до {0}", MainWindow.trapezoidscount));
                        return;
                    }
                    break;
            }
            this.DialogResult = true;
        }
    }
}
         

