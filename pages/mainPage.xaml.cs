using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace prakt8.pages
{
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class mainPage : Page
    {
        Doctor docs = new Doctor();
        Pacient pac = new Pacient( );
        public ObservableCollection<Pacient> pacients { get; set; } = new();

        public mainPage(Doctor doc)
        {
            InitializeComponent();
            docs = doc;
            docInfo.DataContext = docs;
            DataContext = this;


            string[] files = Directory.GetFiles("Pacient", "P_*.json");
            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    Pacient? pac = JsonSerializer.Deserialize<Pacient>(json);
                    if(pac != null) 
                        pacients.Add(pac);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void createPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new createPriem(docs.Id));
        }
        
        private void startPriemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listpac.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете пациента");
            }
            else
            {
                NavigationService.Navigate(new startPriem(pacients [ listpac.SelectedIndex ], docs.Id));
            }
        }

        private void redactInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listpac.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете пациента");
            }
            else
            {
                NavigationService.Navigate(new redactInfo(pacients [ listpac.SelectedIndex ]));
            }
        }

        private void settingBtn_Click (object sender, RoutedEventArgs e)
        {
            settingFrame.frame.Visibility = Visibility.Visible;
            settingFrame.frame.Navigate(new settingPage());
        }
    }
}
