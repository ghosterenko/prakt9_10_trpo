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

namespace prakt8.pages
{
    /// <summary>
    /// Логика взаимодействия для settingPage.xaml
    /// </summary>
    public partial class settingPage :Page
    {
        public settingPage ()
        {
            InitializeComponent( );
        }

        private void hiddenbtn_Click (object sender, RoutedEventArgs e)
        {
            settingFrame.frame.Visibility = Visibility.Collapsed;
        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle( );
        }
    }
}
