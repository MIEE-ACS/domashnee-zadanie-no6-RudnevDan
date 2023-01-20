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
    /// Логика взаимодействия для AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public AddingWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(selectbox.SelectedIndex)
            {
                case 0:
                    a_label.Content = "Радиус";
                    b_label.Visibility = Visibility.Collapsed;
                    b_box.Visibility = Visibility.Collapsed;
                    h_label.Visibility = Visibility.Collapsed;
                    h_box.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    a_label.Content = "Длинна";
                    b_label.Content = "Ширина";
                    b_label.Visibility = Visibility.Visible;
                    b_box.Visibility = Visibility.Visible;
                    h_label.Visibility = Visibility.Collapsed;
                    h_box.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    a_label.Content = "Основание 1";
                    b_label.Content = "Основание 2";
                    b_label.Visibility = Visibility.Visible;
                    b_box.Visibility = Visibility.Visible;
                    h_label.Visibility = Visibility.Visible;
                    h_box.Visibility = Visibility.Visible;
                    break;
            }
        }
        public int a, b, h;

        private void ApplyButtob_Click(object sender, RoutedEventArgs e)
        {
            switch(selectbox.SelectedIndex)
            {
                case 0:
                    try
                    {
                        a = int.Parse(a_box.Text);
                        if (a < 1) throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Укажите радиус положительным числом");
                        return;
                    }
                    break;
                case 1:
                    try
                    {
                        a = int.Parse(a_box.Text);
                        if (a < 1) throw new FormatException();
                        b = int.Parse(b_box.Text);
                        if (b < 1) throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Укажите величины положительным числом");
                        return;
                    }
                    break;
                case 2:
                    try
                    {
                        a = int.Parse(a_box.Text);
                        if (a < 1) throw new FormatException();
                        b = int.Parse(b_box.Text);
                        if (b < 1) throw new FormatException();
                        h = int.Parse(h_box.Text);
                        if (h < 1) throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Укажите величины положительным числом");
                        return;
                    }
                    break;
            }
            this.DialogResult = true;
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
