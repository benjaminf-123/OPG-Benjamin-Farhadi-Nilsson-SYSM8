using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class StrengthWorkout : Workout
    {
        public int Repetitions { get; set; }

        public override int CalculateCaloriesBurned()
        {
            // 1 kalori per repetition 
            CaloriesBurned = Repetitions * 1;
            return CaloriesBurned;


        }
    }
}
