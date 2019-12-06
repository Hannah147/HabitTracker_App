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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HabitTracker_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Habit> allHabits = new List<Habit>();
        List<Goal> allGoals = new List<Goal>();
        static double total = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Method that runs when the window loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create all habits
            Habit habit1 = new Habit()
            {
                HabitName = "Study",
                HabitTarget = 0,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit2 = new Habit()
            {
                HabitName = "Assignments",
                HabitTarget = 0,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit3 = new Habit()
            {
                HabitName = "Write Notes",
                HabitTarget = 0,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit4 = new Habit()
            {
                HabitName = "Attend All Classes",
                HabitTarget = 0,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit5 = new Habit()
            {
                HabitName = "Revision",
                HabitTarget = 0,
                HabitProgress = 0,
                TotalProgress = 0
            };

            // Create all goals
            Goal goal1 = new Goal()
            {
                GoalName = habit1.HabitName,
                GoalDescription = "Study for upcoming exams or CA's",
                GoalProgress = habit1.TotalProgress,
                GoalTarget = habit1.HabitTarget
            };

            Goal goal2 = new Goal()
            {
                GoalName = habit2.HabitName,
                GoalDescription = "Work on Assignments",
                GoalProgress = habit2.TotalProgress,
                GoalTarget = habit2.HabitTarget
            };

            Goal goal3 = new Goal()
            {
                GoalName = habit3.HabitName,
                GoalDescription = "Write up notes on what happened in class",
                GoalProgress = habit3.TotalProgress,
                GoalTarget = habit3.HabitTarget
            };

            Goal goal4 = new Goal()
            {
                GoalName = habit4.HabitName,
                GoalDescription = "Attend all classes during the week",
                GoalProgress = habit4.TotalProgress,
                GoalTarget = habit4.HabitTarget
            };

            Goal goal5 = new Goal()
            {
                GoalName = habit5.HabitName,
                GoalDescription = "Revise over work from during the week",
                GoalProgress = habit5.TotalProgress,
                GoalTarget = habit5.HabitTarget
            };

            // Add all habits to the allHabits list
            allHabits.Add(habit1);
            allHabits.Add(habit2);
            allHabits.Add(habit3);
            allHabits.Add(habit4);
            allHabits.Add(habit5);

            // List all habits in a list box
            lbxAllHabits.ItemsSource = allHabits;

            // Add all goals to the allGoals list
            allGoals.Add(goal1);
            allGoals.Add(goal2);
            allGoals.Add(goal3);
            allGoals.Add(goal4);
            allGoals.Add(goal5);
        }

        // Method to add progress to a habit, and add it to a total
        static double addProgress(double _progress)
        {
            total = 0;
            total = total + _progress;
            return total;
        }

        // Method to compare the total progress to the target of the habit
        public void checkProgress(double target, double finalTotal)
        {
            if (finalTotal == target || finalTotal >= target)
            {
                tblkAnswer.Text = "You have reached your target!";
            }
            else
            {
                tblkAnswer.Text = "Keep trying, you're nearly there!";
            }
        }

        // Method to add a target to a habit
        private void BtnAddTarget_Click(object sender, RoutedEventArgs e)
        {
            Habit selectedHabit = lbxAllHabits.SelectedItem as Habit;

            if (selectedHabit != null)
            {
                selectedHabit.HabitTarget = double.Parse(tbxAddTarget.Text);
                tblkTarget.Text = selectedHabit.HabitTarget.ToString();
                tbxAddTarget.Clear();
                tblkGoal.Text = "";
            }
        }

        // Method to add progress to a habit
        private void BtnAddProgress_Click(object sender, RoutedEventArgs e)
        {
            // Find the selected habit from the list box
            Habit selectedHabit = lbxAllHabits.SelectedItem as Habit;

            // Check if the selected habit is null
            if (selectedHabit != null)
            {
                // Store the info in the text blocks
                tblkHabit.Text = selectedHabit.HabitName;
                tblkCurrent.Text = selectedHabit.HabitProgress.ToString();
                tblkTarget.Text = selectedHabit.HabitTarget.ToString();

                // Read in the input from the progress text box
                selectedHabit.HabitProgress = double.Parse(tbxAddProgress.Text);
                // Add to the total progress of the selected habit
                selectedHabit.TotalProgress = addProgress(selectedHabit.HabitProgress) + selectedHabit.TotalProgress;
                // Add the answer to the Current text block
                tblkCurrent.Text = selectedHabit.TotalProgress.ToString();
                // Check if the user has reached their goal target
                checkProgress(selectedHabit.HabitTarget, selectedHabit.TotalProgress);

                foreach (Goal goal in allGoals)
                {
                    if (selectedHabit.HabitName == goal.GoalName)
                    {
                        goal.GoalProgress = selectedHabit.TotalProgress;
                        goal.GoalTarget = selectedHabit.HabitTarget;
                        tblkGoal.Text = goal.ToString();
                        tbxAddProgress.Clear();
                    }
                }
            }
        }

        // Method that runs when you click on a different item in the list box
        private void LbxAllHabits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Habit selectedHabit = lbxAllHabits.SelectedItem as Habit;
            
            if (selectedHabit != null)
            {
                // Clear the Answer text block, and the goal text block, and the add progress text box
                tblkAnswer.Text = "";
                tblkGoal.Text = "";
                tbxAddProgress.Clear();
                tblkHabit.Text = selectedHabit.HabitName;
                // Add the current info, and target info to the text blocks
                tblkCurrent.Text = selectedHabit.TotalProgress.ToString();
                tblkTarget.Text = selectedHabit.HabitTarget.ToString();
            }
        }    
    }
}
