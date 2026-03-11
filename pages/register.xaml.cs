using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using System.IO;

namespace prakt8.pages
{
    /// <summary>
    /// Логика взаимодействия для register.xaml
    /// </summary>
    public partial class register : Page
    {
        Doctor docReg = new Doctor();
        public register()
        {
            InitializeComponent();
            regDoc.DataContext = docReg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool f = false;
            Random rnd = new( );
            int idDoc = rnd.Next(10, 10000);
            string [ ] doctors = Directory.GetFiles("Doctor", "D_*.json");
            foreach (var item in doctors)
            {
                try
                {
                    string json = File.ReadAllText(item);
                    Doctor? tDoc = JsonSerializer.Deserialize<Doctor>(json);
                    if (tDoc?.Id == idDoc)
                    {
                        idDoc = rnd.Next(10, 10000);
                    }
                    else
                    {
                        f = true;
                    }
                }
                catch { }
            }
            if (f == true)
            {
                docReg.Id = idDoc;
            }
            else
            {
                docReg.Id = 0;
            }


            try
            {

                string json = JsonSerializer.Serialize<Doctor>(docReg);
                File.WriteAllText($"Doctor\\D_{docReg.Id}.json", json);
                MessageBox.Show("Доктор зарегестрирован");
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
