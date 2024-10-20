using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            string username = usrnameinput.Text;
            string password = Pwdinput.Password;

            if (username == "..." && password == "...")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. ", "Login failed");
            }

            
        }

        private void Register_click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}