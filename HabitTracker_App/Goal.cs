using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker_App
{
    class Goal
    {
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public double GoalTarget { get; set; }
        public double GoalProgress { get; set; }

        public Goal(string goalName, string goalDescription, double goalTarget, double goalProgress)
        {
            GoalName = goalName;
            GoalDescription = goalDescription;
            GoalTarget = goalTarget;
            GoalProgress = goalProgress;
        }

        public Goal() : this("Unknown", "Unknown", 0, 0)
        {

        }

        public override string ToString()
        {
            return $"Goal Description : {GoalDescription}\n" +
                $"Goal Progress : {GoalProgress}\n" +
                $"Goal Target : {GoalTarget}";
        }
    }
}
