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
using System.Collections.ObjectModel;

namespace prakt8.pages
{
    /// <summary>
    /// Логика взаимодействия для startPriem.xaml
    /// </summary>
    public partial class startPriem : Page
    {
        public int IdDoc;
        Pacient pac = new Pacient( );
        Priem priem = new Priem( );

        public startPriem(Pacient pacient, int idDoc)
        {
            InitializeComponent();
            pac = pacient;
            IdDoc = idDoc;
            DataContext = pac;
        }

        private void exitBtn_Click (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack( );
        }

        private void addPriemBtn_Click (object sender, RoutedEventArgs e)
        {
            priemAdd.DataContext = priem;
            priem.Lastdoc = IdDoc;
            priem.LastP = DateTime.Now;

            pac.Priems.Add(priem);

            try
            {
                string json = JsonSerializer.Serialize<Pacient>(pac);
                File.WriteAllText($"Pacient\\P_{pac.Id}.json", json);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
