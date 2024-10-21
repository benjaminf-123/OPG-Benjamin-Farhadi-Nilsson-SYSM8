using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class CardioWorkout : Workout    
    {
        public int Distance { get; set; }

        public override int CalculateCaloriesBurned()
        {
            
            CaloriesBurned = Distance * 2; 
            return CaloriesBurned;
        }
    }
}
