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
using System.Text.Json;
using System.IO;

namespace prakt8.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void registrBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new register());
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            bool f = false;
            string[] files = Directory.GetFiles("Doctor", "D_*.json");
            Array.Sort(files);
            Doctor doc = new Doctor();
            foreach (string file in files) 
            {
                try
                {
                    string json = File.ReadAllText(file);
                    Doctor? doctor = JsonSerializer.Deserialize<Doctor>(json);
                    if (doctor?.Id == int.Parse(idTb.Text) && doctor.Pass == passwordTb.Text)
                    {
                        doc = doctor;
                        f = true;
                        break;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
            if(f == true)
            {
                NavigationService.Navigate(new mainPage(doc));
            }
            else
            {
                MessageBox.Show("Неверный id или пароль");
            }
        }
    }
}
