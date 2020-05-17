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
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MMFitnessApp
{
    public partial class MyBMRPage : ContentPage
    {
        public MyBMRPage()
        {
            InitializeComponent();

            // set default Picker for activity level and gender.
            PckActivity.SelectedIndex = 0;
            PckGender.SelectedIndex = 0;
        }


        /// <summary>
        /// Calculate BMR and calories from user input for: activity level, gender, age, weight, and height. Then display results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void BtnCalculate_Clicked(System.Object sender, System.EventArgs e)
        {
            // Show BMR Page as a Modal
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            var modalPage = new MyProfilePage();
            modalPage.Disappearing += (sender2, e2) =>
            {
                waitHandle.Set();
            };
            await Navigation.PushModalAsync(modalPage);
            await Task.Run(() => waitHandle.WaitOne());


            // Declare constants for Female BMR
            const int FEMALE_1 = 655;
            decimal FEMALE_2 = 4.35m;
            decimal FEMALE_3_4 = 4.7m;


            // Declare constants for Male BMR
            const int MALE_1 = 66;
            decimal MALE_2 = 6.23m;
            decimal MALE_3 = 12.7m;
            decimal MALE_4 = 6.8m;

            // Declare constants for activity levels
            const decimal NONE = 1.2m;
            decimal LIGHT = 1.375m;
            decimal MODERATE = 1.55m;
            decimal HEAVY = 1.725m;
            decimal VERY_HEAVY = 1.9m;


            // Pass information for selected male gender.
            if (PckGender.SelectedItem.ToString() == "Male")
            {
                // Pass information for selected activity level.
                switch (PckActivity.SelectedItem.ToString())
                {
                    case "Little to No Activity":
                        // Pass calculation for when male and little/no exercise is selected. Display result to two decimal places.
                        lblMaleResults.Text = ((MALE_1 + (MALE_2 * (decimal)FitnessGlobalVariables.Weight) + (MALE_3 * (decimal)FitnessGlobalVariables.Height) - (MALE_4 * (decimal)FitnessGlobalVariables.Age)) * NONE).ToString("n2");
                        break;

                    case "Light Activity (1-3 days per week)":
                        // Pass calculation for when male and light exercise is selected. Display result to two decimal places.
                        lblMaleResults.Text = ((MALE_1 + (MALE_2 * (decimal)FitnessGlobalVariables.Weight) + (MALE_3 * (decimal)FitnessGlobalVariables.Height) - (MALE_4 * (decimal)FitnessGlobalVariables.Age)) * LIGHT).ToString("n2");
                        break;

                    case "Moderate Activity (3-5 days per week)":
                        // Pass calculation for when male and moderate exercise is selected. Display result to two decimal places.
                        lblMaleResults.Text = ((MALE_1 + (MALE_2 * (decimal)FitnessGlobalVariables.Weight) + (MALE_3 * (decimal)FitnessGlobalVariables.Height) - (MALE_4 * (decimal)FitnessGlobalVariables.Age)) * MODERATE).ToString("n2");
                        break;

                    case "Heavy Activity (6-7 days per week)":
                        // Pass calculation for when male and heavy exercise is selected. Display result to two decimal places.
                        lblMaleResults.Text = ((MALE_1 + (MALE_2 * (decimal)FitnessGlobalVariables.Weight) + (MALE_3 * (decimal)FitnessGlobalVariables.Height) - (MALE_4 * (decimal)FitnessGlobalVariables.Age)) * HEAVY).ToString("n2");
                        break;

                    case "Very Heavy Activity (twice per day)":
                        // Pass calculation for when male and very heavy exercise is selected. Display result to two decimal places.
                        lblMaleResults.Text = ((MALE_1 + (MALE_2 * (decimal)FitnessGlobalVariables.Weight) + (MALE_3 * (decimal)FitnessGlobalVariables.Height) - (MALE_4 * (decimal)FitnessGlobalVariables.Age)) * VERY_HEAVY).ToString("n2");
                        break;
                }
            }

            // Pass information for when users select female gender.
            else if (PckGender.SelectedItem.ToString() == "Female")
            {
                // Pass information for selected activity level.
                switch (PckActivity.SelectedItem.ToString())
                {
                    case "Little to No Activity":
                        // Pass calculation for when female and little/no exercise is selected. Display result to two decimal places.
                        lblFemaleResults.Text = ((FEMALE_1 + (FEMALE_2 * (decimal)FitnessGlobalVariables.Weight) + (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Height) - (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Age)) * NONE).ToString("n2");
                        break;


                    case "Light Activity (1-3 days per week)":
                        // Pass calculation for when female and light exercise is selected. Display result to two decimal places.
                        lblFemaleResults.Text = ((FEMALE_1 + (FEMALE_2 * (decimal)FitnessGlobalVariables.Weight) + (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Height) - (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Age)) * LIGHT).ToString("n2");
                        break;


                    case "Moderate Activity (3-5 days per week)":
                        // Pass calculation for when female and moderate exercise is selected. Display result to two decimal places.
                        lblFemaleResults.Text = ((FEMALE_1 + (FEMALE_2 * (decimal)FitnessGlobalVariables.Weight) + (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Height) - (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Age)) * MODERATE).ToString("n2");
                        break;


                    case "Heavy Activity (6-7 days per week)":
                        // Pass calculation for when female and heavy exercise is selected. Display result to two decimal places.
                        lblFemaleResults.Text = ((FEMALE_1 + (FEMALE_2 * (decimal)FitnessGlobalVariables.Weight) + (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Height) - (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Age)) * HEAVY).ToString("n2");
                        break;


                    case "Very Heavy Activity (twice per day)":
                        // Pass calculation for when female and very heavy exercise is selected. Display result to two decimal places.
                        lblFemaleResults.Text = ((FEMALE_1 + (FEMALE_2 * (decimal)FitnessGlobalVariables.Weight) + (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Height) - (FEMALE_3_4 * (decimal)FitnessGlobalVariables.Age)) * VERY_HEAVY).ToString("n2");
                        break;
                }
            }
        }

        /// <summary>
        /// Close BMR Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///

        private void btnClose_Clicked(System.Object sender, System.EventArgs e)
        {
            // Close the current BMR Page and return to the Main Page
            Navigation.PopModalAsync();
        }
    }
}
