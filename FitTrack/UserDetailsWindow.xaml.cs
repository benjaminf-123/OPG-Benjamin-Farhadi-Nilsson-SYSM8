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


            if (newUsername.Length < 3)
            {
                ErrorMessage.Text = "Username must be at least 3 characters.";
                return;
            }

            if (IsUsernameTaken(newUsername))
            {
                ErrorMessage.Text = "Username is already taken.";
                return;
            }
            if (newPassword != ConfirmPassword)
            {
                ErrorMessage.Text = "Passwords do not match.";
                return;
            }
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

