﻿using System;
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
            if (PwdInput.Password != ConfirmPwd.Password)
            {
                ErrorMessage.Text = "Passwords do not match";
                return;
            }
            if (PwdInput.Password.Length < 8 ||
               !PwdInput.Password.Any(char.IsDigit) ||
               !PwdInput.Password.Any(char.IsPunctuation))
            {
                ErrorMessage.Text = "Password must be at least 8 characters long, with at least one number and one special character.";
                return;
            }
            if (IsUsernameTaken(UsernameInput.Text))
            {
                ErrorMessage.Text = "Username is already taken.";
                return;
            }


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
