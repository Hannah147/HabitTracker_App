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
        static double total = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Habit habit1 = new Habit()
            {
                HabitName = "Study",
                HabitTarget = 20000,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit2 = new Habit()
            {
                HabitName = "Assignments",
                HabitTarget = 40000,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit3 = new Habit()
            {
                HabitName = "Write Notes",
                HabitTarget = 10000,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit4 = new Habit()
            {
                HabitName = "Attend All Classes",
                HabitTarget = 30000,
                HabitProgress = 0,
                TotalProgress = 0
            };

            Habit habit5 = new Habit()
            {
                HabitName = "Revision",
                HabitTarget = 50000,
                HabitProgress = 0,
                TotalProgress = 0
            };

            allHabits.Add(habit1);
            allHabits.Add(habit2);
            allHabits.Add(habit3);
            allHabits.Add(habit4);
            allHabits.Add(habit5);

            lbxAllHabits.ItemsSource = allHabits;
        }

        static double addProgress(double _progress)
        {
            total = 0;
            total = total + _progress;
            return total;
        }

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

        private void BtnAddProgress_Click(object sender, RoutedEventArgs e)
        {
            Habit selectedHabit = lbxAllHabits.SelectedItem as Habit;

            if (selectedHabit != null)
            {
                tbxHabit.Text = selectedHabit.HabitName;
                tblkCurrent.Text = selectedHabit.HabitProgress.ToString();
                tblkTarget.Text = selectedHabit.HabitTarget.ToString();

                selectedHabit.HabitProgress = double.Parse(tbxAddProgress.Text);
                selectedHabit.TotalProgress = addProgress(selectedHabit.HabitProgress) + selectedHabit.TotalProgress;
                tblkCurrent.Text = selectedHabit.TotalProgress.ToString();
                checkProgress(selectedHabit.HabitTarget, selectedHabit.TotalProgress);
            }

        }

        private void LbxAllHabits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Habit selectedHabit = lbxAllHabits.SelectedItem as Habit;
            if (selectedHabit != null)
            {
                tbxAddProgress.Clear();
                tbxHabit.Text = selectedHabit.HabitName;
                tblkCurrent.Text = selectedHabit.TotalProgress.ToString();
                tblkTarget.Text = selectedHabit.HabitTarget.ToString();
            }
        }
    }
}
