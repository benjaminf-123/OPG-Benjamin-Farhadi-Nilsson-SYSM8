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
            
            // Hämtar användarnamn och lösenord från inmatningsfälten
            string username = usrnameinput.Text;
            string password = Pwdinput.Password;

            
            // Kontrollerar om användarnamnet och lösenordet matchar
            if (username == "..." && password == "...")
            {
                var workoutsWindow = new WorkoutsWindow();
                
                // Sätter inloggad användare i WorkoutsWindow
                workoutsWindow.User = new User { Username = username }; 
                workoutsWindow.Show();
                this.Close();
                
            }
            else
            {
                
                // Visar ett felmeddelande om inloggningsuppgifterna är felaktiga
                MessageBox.Show("Invalid username or password. ", "Login failed");
            }

            
        }

        

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            {

                // Skapar och öppnar RegisterWindow när användaren klickar på Register
                var registerWindow = new RegisterWindow();
                registerWindow.Show();

                this.Close();
            }

        }

    }
    }
