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
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    public partial class WorkoutsWindow : Window
    {
        public User User { get; set; }
        public List<Workout> WorkoutList { get; set; }

        public WorkoutsWindow()
        {
            InitializeComponent();
            WorkoutList = new List<Workout>();
        }


        // Uppdatera listan med träningspass
        private void RefreshWorkoutList()
        {
            WorkoutsList.ItemsSource = null;
            WorkoutsList.ItemsSource = WorkoutList;
        }

        // Ta bort träningspass
        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorkout = (Workout)WorkoutsList.SelectedItem;
            if (selectedWorkout != null)
            {
                WorkoutList.Remove(selectedWorkout);
                RefreshWorkoutList();
            }
        }

        // Visa detaljer om träningspass
        private void DetailsWorkout_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorkout = (Workout)WorkoutsList.SelectedItem;
            if (selectedWorkout != null)
            {
                var detailsWindow = new WorkoutDetailsWindow(selectedWorkout);
                detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a workout first.");
            }
        }

        //Lägga till passs
        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            var addWorkoutWindow = new AddWorkoutWindow();

            // Öppna fönstret och lägg till träningspasset
            if (addWorkoutWindow.ShowDialog() == true)
            {
                Workout newWorkout = addWorkoutWindow.NewWorkout;
                WorkoutList.Add(newWorkout);
                RefreshWorkoutList();
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
