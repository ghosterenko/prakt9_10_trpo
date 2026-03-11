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
    /// Логика взаимодействия для redactInfo.xaml
    /// </summary>
    public partial class redactInfo : Page
    {
        Pacient pacient = new Pacient( );
        public redactInfo(Pacient pac)
        {
            InitializeComponent();
            pacient = pac;
            DataContext = pac;
        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                string json = JsonSerializer.Serialize<Pacient>(pacient);
                File.WriteAllText($"Pacient\\P_{pacient.Id}.json", json);
                MessageBox.Show("Успех");
                NavigationService.GoBack( );
            }
            catch { }
        }

        private void exitBtn_Click (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack( );
        }
    }
}
