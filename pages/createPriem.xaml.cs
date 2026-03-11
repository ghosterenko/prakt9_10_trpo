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
    /// Логика взаимодействия для createPriem.xaml
    /// </summary>
    public partial class createPriem : Page
    {

        public int Id;
        Pacient pac = new Pacient();

        public createPriem(int id)
        {
            InitializeComponent();
            Id = id;
            createsp.DataContext = pac;
        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            bool f = false;
            Random rnd = new( );
            int idPac = rnd.Next(10, 10000);
            string [ ] pacients = Directory.GetFiles("Pacient", "P_*.json");
            foreach (var item in pacients)
            {
                try
                {
                    string json = File.ReadAllText(item);
                    Pacient? tPac = JsonSerializer.Deserialize<Pacient>(json);
                    if (tPac?.Id == idPac)
                    {
                        idPac = rnd.Next(10, 10000);
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
                pac.Id = idPac;
            }
            else
            {
                pac.Id = 0;
            }

            try
            {
                string json = JsonSerializer.Serialize<Pacient>(pac);
                File.WriteAllText($"Pacient\\P_{pac.Id}.json", json);
                MessageBox.Show("Пациент добавлен");
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
