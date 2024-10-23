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
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        public Workout NewWorkout { get; private set; }
        public AddWorkoutWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollera användarinmatning och skapa ett nytt träningspass
            if (WorkoutTypeComboBox.SelectedItem != null && !string.IsNullOrEmpty(WorkoutDetailsInput.Text))
            {
                if (WorkoutTypeComboBox.SelectedItem.ToString() == "Cardio")
                {
                    NewWorkout = new CardioWorkout
                    {
                        Distance = int.Parse(WorkoutDetailsInput.Text)
                    };
                }
                else
                {
                    NewWorkout = new StrengthWorkout
                    {
                        Repetitions = int.Parse(WorkoutDetailsInput.Text)
                    };
                }
                this.DialogResult = true; 
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid workout details.");
            }
        }



        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }
    }
}

