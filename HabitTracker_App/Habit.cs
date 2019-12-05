using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker_App
{
    public class Habit
    {
        public string HabitName { get; set; }
        public double HabitTarget { get; set; }
        public double HabitProgress { get; set; }
        public double TotalProgress { get; set; }

        public Habit(string habitName, double habitTarget, double habitProgress, double totalProgress)
        {
            HabitName = habitName;
            HabitTarget = habitTarget;
            HabitProgress = habitProgress;
            TotalProgress = totalProgress;
        }

        public Habit():this("Unknown", 0, 0, 0)
        {

        }

        public override string ToString()
        {
            return $"{HabitName}";
        }
    }
}
