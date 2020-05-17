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

using Xamarin.Forms;

namespace MMFitnessApp
{
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
        }

        // Declare variables
        double weight, height, age;

        // Declare constants for minimum and maximum range for the weight, height, and age.
        const int MIN_WEIGHT = 50;
        const int MAX_WEIGHT = 1000;
        const int MIN_HEIGHT = 48;
        const int MAX_HEIGHT = 96;
        const int MIN_AGE = 12;
        const int MAX_AGE = 120;


        /// <summary>
        /// Set variables and return to main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClose_Clicked(System.Object sender, System.EventArgs e)
        {
            // Validate user input for weight. Weight entered should be between 50 and 1000 pounds.
            if (double.TryParse(txtBoxWeight.Text, out weight) && weight <= MAX_WEIGHT && weight >= MIN_WEIGHT)
            {
                // Validate user input for height. Height entered should be between 48 and 96 inches.
                if (double.TryParse(txtBoxHeight.Text, out height) && height <= MAX_HEIGHT && height >= MIN_HEIGHT)
                {
                    // Validate user input for age. Age entered should be between 12 and 120 years.
                    if (double.TryParse(txtBoxAge.Text, out age) && age <= MAX_AGE && age >= MIN_AGE)
                    {
                        // Set global variables
                        FitnessGlobalVariables.Weight = double.Parse(txtBoxWeight.Text);
                        FitnessGlobalVariables.Height = double.Parse(txtBoxHeight.Text);
                        FitnessGlobalVariables.Age = double.Parse(txtBoxAge.Text);


                        // Return to main page by "taking off" or "removing" the MyProfilePage after clicking the close button.
                        Application.Current.MainPage.Navigation.PopModalAsync();

                    }
                    
                    // If age entered is not between 12 and 120 years old
                    else
                    {
                        // Display alert when "Close" button is clicked if user entry is not between 12 and 120 years old.
                        DisplayAlert("Invalid Age", $"Please enter an age between {MIN_AGE} and {MAX_AGE}.", "Close");

                        // Clear incorrect user input for height, weight, and age but keep other information
                        txtBoxHeight.Text = "";
                        txtBoxWeight.Text = "";
                        txtBoxAge.Text = "";
                    }

                    }

                // If height entered is not between 48 and 96 inches.
                else
                {
                    //  Display alert when "Close" button is clicked if user entry is not between 48 and 96 inches.
                    DisplayAlert("Invalid Height", $"Please enter a height between {MIN_HEIGHT} and {MAX_HEIGHT}.", "Close");

                    // Clear incorrect user input for height, weight, and age but keep other information
                    txtBoxHeight.Text = "";
                    txtBoxWeight.Text = "";
                    txtBoxAge.Text = "";
                }

            }
            // If weight entered is not between 50 and 1000 pounds or if all fields are left empty.
            else
            {
                //  Display alert when "Close" button is clicked if user entry is not between 50 and 1000 years old or all field entries are left empty.
                DisplayAlert("Invalid Input", $"Please enter a value for weight between {MIN_WEIGHT} and {MAX_WEIGHT}, height between {MIN_HEIGHT} and {MAX_HEIGHT}, and an age between {MIN_AGE} and {MAX_AGE}.", "Close");

                // Clear incorrect user input for height, weight, and age but keep other information
                txtBoxHeight.Text = "";
                txtBoxWeight.Text = "";
                txtBoxAge.Text = "";
            }


        }




        /// <summary>
        /// Show before image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void btnBefore_Clicked(System.Object sender, System.EventArgs e)
        {
            // By pushing the "Before" button the before image will be displayed.
            ImgProfile.Source = "Before.jpg";
        }


        /// <summary>
        /// After image and alert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void btnAfter_Clicked(System.Object sender, System.EventArgs e)
        {
            // By pushing the "After" button the after image will be displayed.
            ImgProfile.Source = "After.jpg";

            // When "After" button is pushed a pop-up window for encouraging message that users can close after read.
            DisplayAlert("Good Job", "You're doing great!", "Close");
        }

        /// <summary>
        /// Clear entire form and set weight, height, and age to 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnClear_Clicked(System.Object sender, System.EventArgs e)
        {
            // Clear all entries to be empty
            FirstName.Text = "";
            LastName.Text = "";
            PreferedName.Text = "";
            txtBoxAge.Text = "";
            txtBoxHeight.Text = "";
            txtBoxWeight.Text = "";

            // Set age, height, weight to zero.
            txtBoxHeight.Text = "0";
            txtBoxWeight.Text = "0";
            txtBoxAge.Text = "0";
        }
    }
}
