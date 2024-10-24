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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private User CurrentUser;
        public UserDetailsWindow(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            LoadUserDetails();
        }
        private void LoadUserDetails()
        {
            CurrentUsername.Text = CurrentUser.Username;
            CountryComboBox.Text = CurrentUser.Country;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = NewUsrnameInput.Text;
            string newPassword = NewPwdInput.Password;
            string ConfirmPassword = ConfirmPwdInput.Password;
            string selectedCountry = CountryComboBox.Text;


            // Kontroll av att det nya användarnamnet är tillräckligt långt (minst 3 tecken)
            if (newUsername.Length < 3)
            {
                ErrorMessage.Text = "Username must be at least 3 characters.";
                return;
            }
            
            // Kontroll av att användarnamnet inte är upptaget
            if (IsUsernameTaken(newUsername))
            {
                ErrorMessage.Text = "Username is already taken.";
                return;
            }

            // Kontroll av att lösenorden matchar
            if (newPassword != ConfirmPassword)
            {
                ErrorMessage.Text = "Passwords do not match.";
                return;
            }
           
             // Kontroll av att lösenordet är minst 5 tecken långt
            if (newPassword.Length < 5)
            {
                ErrorMessage.Text = "Password must be at least 5 characters.";
                return;
            }
            CurrentUser.Username = newUsername;
            CurrentUser.Password = newPassword;
            CurrentUser.Country = selectedCountry;

            MessageBox.Show("User details updated successfully!");
            this.Close();
        }
        
        //kontrollera om användarnamnet redan är upptaget
        private bool IsUsernameTaken(string username)
        {
            return username == "admin";
        }

            private void CancelBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Close();

            }
        }
    }

