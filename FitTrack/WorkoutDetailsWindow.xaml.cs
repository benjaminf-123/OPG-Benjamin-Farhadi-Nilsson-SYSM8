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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        private Workout CurrentWorkout;

        public WorkoutDetailsWindow(Workout workout)
        {
            InitializeComponent();
            CurrentWorkout = workout;
            LoadWorkoutDetails();
        }

        private void LoadWorkoutDetails()
        {
            // Fyller i med data från träningspasset
            WorkoutDateInput.Text = CurrentWorkout.Date.ToString("yyyy-MM-dd");
            WorkoutTypeInput.Text = CurrentWorkout.Type;

            // Kolla om det är ett Cardio eller Strength träningspass
            if (CurrentWorkout is CardioWorkout cardioWorkout)
            {
                WorkoutDetailsInput.Text = $"Distance: {cardioWorkout.Distance} meters";
            }
            else if (CurrentWorkout is StrengthWorkout strengthWorkout)
            {
                WorkoutDetailsInput.Text = $"Repetitions: {strengthWorkout.Repetitions}";
            }

            // Visa beräknade kalorier
            CaloriesBurnedInput.Text = CurrentWorkout.CalculateCaloriesBurned().ToString();
        }
        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            // sparandet av nya träningsdetaljer
            if (CurrentWorkout is CardioWorkout cardioWorkout)
            {
                // Uppdatera distans om det är Cardio
                if (int.TryParse(WorkoutDetailsInput.Text.Replace("Distance: ", "").Replace(" meters", ""), out int distance))
                {
                    cardioWorkout.Distance = distance;
                }
            }
            else if (CurrentWorkout is StrengthWorkout strengthWorkout)
            {
                // Uppdatera repetitioner om det är Strength
                if (int.TryParse(WorkoutDetailsInput.Text.Replace("Repetitions: ", ""), out int repetitions))
                {
                    strengthWorkout.Repetitions = repetitions;
                }
            }

            MessageBox.Show("Workout details updated successfully!");
            this.Close();
        }




        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
