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

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }


       
        
        
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            
            // Kontrollera om lösenorden matchar
            if (PwdInput.Password != ConfirmPwd.Password)
            {
                ErrorMessage.Text = "Passwords do not match";
                return;
            }
            
            // Kontrollera ifall lösenordet har minst 8 tecken, en siffra och ett specialtecken
            if (PwdInput.Password.Length < 8 ||
               !PwdInput.Password.Any(char.IsDigit) ||
               !PwdInput.Password.Any(char.IsPunctuation))
            {
                ErrorMessage.Text = "Password must be at least 8 characters long, with at least one number and one special character.";
                return;
            }
            
            // Kontrollera om användarnamnet redan är upptaget
            if (IsUsernameTaken(UsernameInput.Text))
            {
                ErrorMessage.Text = "Username is already taken.";
                return;
            }

            // Skapa en ny användare och ge användaren ett användarnamn, lösenord och land
            var newUser = new User
            {
                Username = UsernameInput.Text,
                Password = PwdInput.Password,
                Country = CountryComboBox.Text
            };


            MessageBox.Show("User registered successfully!");


            this.Close();

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        
        // Kontrollera ifall användarnamnet redan är upptaget
        private bool IsUsernameTaken(string username)
        {
            if (username == "admin")
            {
                return true;
            }

            return false;
        }

        private void PwdInput_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ConfirmPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

