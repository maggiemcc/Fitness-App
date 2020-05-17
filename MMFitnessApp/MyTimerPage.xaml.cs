//Name: Maggie McCausland
//Class: (INFO 1200)
//Section: (001)
//Professor: (Crandall)
//Date: 3/14/2020
//Project #: Project7B
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MMFitnessApp
{
    public partial class MyTimerPage : ContentPage
    {
        // Constants for minutes and double digits.
        int MINUTE = 60, DOUBLE_DIGITS = 10;

        // Variable for lap count.
        int lapCount = 1;

        // Variables for time (set time equal to zero) and direction.
        string direction = "";
        int time = 0;

        public MyTimerPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Delay the timer count by 1000 milliseconds (1 second).
        /// </summary>
        /// <returns></returns>
        private async Task StartTimer()
        {
            // Delay task by 10000 milliseconds
            await Task.Delay(1000);
        }



        /// <summary>
        /// Start button will convert the time users enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStart_Clicked(System.Object sender, System.EventArgs e)
        {
            // if SetTime() is true
            if (true)
            {
                // Calculate and display user input.
                DisplayTime(time);

                // Validate direction has been chosen by user.
                if (GetDirection(ref direction))
                {
                    // Down is selected for picker.
                    if (direction == "Down")
                    {
                        // If direction is Down then do Count Down timer.
                        var task = CountDown(); await task;
                    }

                    else
                    {
                        if (direction == "Up")
                        {
                            // If the direction is Up then do Count Up timer.
                            var task = CountUp(); await task;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Have time count down to zero from user input.
        /// </summary>
        /// <returns></returns>
        private async Task CountDown()
        {
            // Validate user entry and determine if it can be parsed.
            if (int.TryParse(StartTimeEntry.Text, out int time))
            {
                // Hide start button to prevent user from starting another time until countdown is finished.
                BtnStart.IsEnabled = false;

                // If time entered is greater than or equal to zero. 
                while (time >= 0)
                {
                    // Calculates and displays results.
                    DisplayTime(time);
                    // Calls the StartTimer async method
                    Task task = StartTimer();
                    // Await until the task is completed
                    await task;
                    // Time count down from user input.
                    time--;
                }

                // Start button becomes available again after countdown is complete.
                BtnStart.IsEnabled = true;

                // Clear user input after countdown is complete.
                StartTimeEntry.Text = "";
            }

            else
            {
                // Display alert if user input is invalid or entry is empty.
                await DisplayAlert("Invalid Input", "Please enter a number for time.", "Close");

                // Clear invalid user input
                StartTimeEntry.Text = "";
            }
        }



        /// <summary>
        /// Have time count up to user input from zero.
        /// </summary>
        /// <returns></returns>
        private async Task CountUp()
        {
            // Validate user entry and determine if it can be parsed.
            if (int.TryParse(StartTimeEntry.Text, out int time))
            {
                // variable for maxTime, maxTime equals time.
                int maxTime = time;

                //Set time to equal zero.
                time = 0;

                // Hide start button to prevent user from starting another time until countdown is finished.
                BtnStart.IsEnabled = false;

                // If time entered is greater than or equal to zero. 
                while (time <= maxTime)
                {
                    // Run calculations for user input and display results.
                    DisplayTime(time);
                    // Calls the StartTimer async method
                    Task task = StartTimer();
                    // Await until the task is completed
                    await task;
                    // Time count down from user input.
                    time++;
                }

                // Start button becomes available again after countdown is complete.
                BtnStart.IsEnabled = true;

                // Clear user input after countdown is complete.
                StartTimeEntry.Text = "";
            }

            else
            {
                // Display alert if user input is invalid or entry is empty.
                await DisplayAlert("Invalid Input", "Please enter a number for time.", "Close");

                // Clear invalid user input
                StartTimeEntry.Text = "";
            }
        }


        /// <summary>
        /// Calculate and display user input.
        /// </summary>
        /// <param name="time">Set time for user input for amount of time.</param>
        private void DisplayTime(int time)
        {

            // Validate user input for seconds.
            //if (int.TryParse(StartTimeEntry.Text, out int userSeconds))
            //{
                // Set minutes from user input.
                int minutes = time / MINUTE;

                // Set seconds from user input.
                int seconds = time % MINUTE;

                // If minutes is greater than or equal to 10.
                if (minutes >= DOUBLE_DIGITS)
                {
                    // If seconds is greater than or equal to 10.
                    if (seconds >= DOUBLE_DIGITS)
                    {
                        // Minutes are greater than/equal to 10 mins. Seconds are also greater than/equal to 10 seconds.
                        LblTimer.Text = $"{minutes}:{seconds}";
                    }

                    else
                    {
                        // Minutes is greater than 10 but seconds is not greater than 10.
                        LblTimer.Text = $"{minutes}:0{seconds}";
                    }
                }

                else
                {
                    // Minutes is not greater than 10 minutes.
                    if (seconds >= DOUBLE_DIGITS)
                    {
                        // Minutes is less than 10, seconds is greater than 10.
                        LblTimer.Text = $"0{minutes}:{seconds}";
                    }

                    else
                    {
                        // Minutes and seconds are both less than 10.
                        LblTimer.Text = $"0{minutes}:0{seconds}";
                    }
                }
            //}
        }



        /// <summary>
        /// Determine which timer will be used based on user picker selection.
        /// </summary>
        /// <param name="direction">Set direction for user input for direction.</param>
        /// <returns></returns>
        private bool GetDirection(ref string direction)
        {
            // If user has selected an item from the picker.
            if (PckDirection.SelectedIndex >= 0)
            {
                // If up is seleted from picker.
                if (PckDirection.SelectedItem.ToString() == "Up")
                {
                    // Use Count Up timer due to Up being selected.
                    var task = CountUp();
                }
                else
                {
                    // If Down is selected from picker.
                    if (PckDirection.SelectedItem.ToString() == "Down")
                    {
                        // Use count down timer due to Down being selected.
                        var task = CountDown();
                    }
                }
                // Return value user selected
                return true;
            }

            else
            {
                // Display alert if a direction is not chosen.
                DisplayAlert("Invalid Input", "Please select up or down.", "Close");
                return false;
            }
        }



        /// <summary>
        /// Will close the MyTimerPage and return users to the main page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnClose_Clicked(System.Object sender, System.EventArgs e)
        {
            // Close the current BMR Page and return to the Main Page
            Application.Current.MainPage.Navigation.PopModalAsync();
        }



        /// <summary>
        /// Display lap number and time when "Get Lap Time" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnLapTime_Clicked(System.Object sender, System.EventArgs e)
        {

            // Validate user input for seconds.
            if (int.TryParse(StartTimeEntry.Text, out int userSeconds))
            {
                // Set minutes from user input.
                int minutes = userSeconds / MINUTE;

                // Set seconds from user input.
                int seconds = userSeconds % MINUTE;


                // If minutes is greater than or equal to 10.
                if (minutes >= DOUBLE_DIGITS)
                {

                    // If seconds is greater than or equal to 10.
                    if (seconds >= DOUBLE_DIGITS)
                    {
                        // Minutes are greater than/equal to 10 mins. Seconds are also greater than/equal to 10 seconds. Also, display lap number with time stamp.
                        LblResults.Text = LblResults.Text + $"[Lap: " + lapCount + " - " + LblTimer.Text + "] ";
                    }

                    else
                    {
                        // Minutes is greater than 10 but seconds is not greater than 10.  Also, display lap number with time stamp.
                        LblResults.Text = LblResults.Text + $"[Lap: " + lapCount + " - " + LblTimer.Text + "] ";
                    }
                }

                else
                {
                    // Minutes is not greater than 10 minutes.
                    if (seconds >= DOUBLE_DIGITS)
                    {
                        // Minutes is less than 10, seconds is greater than 10. Also, display lap number with time stamp.
                        LblResults.Text = LblResults.Text + $"[Lap: " + lapCount + " - " + LblTimer.Text + "] ";
                    }

                    else
                    {
                        // Minutes and seconds are both less than 10. Also, display lap number with time stamp.
                        LblResults.Text = LblResults.Text + $"[Lap: " + lapCount + " - " + LblTimer.Text + "] ";
                    }
                }

                // Increase lap number by one each time "Get Lap Time" button is pushed.
                lapCount++;
            }
        }


    }
}