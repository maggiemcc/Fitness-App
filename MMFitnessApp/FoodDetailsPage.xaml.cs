//Name: Maggie McCausland
//Class: (INFO 1200)
//Section: (001)
//Professor: (Crandall)
//Date: 4/17/2020
//Project #: Project9B
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.

using System;
using System.Collections.Generic;

using Xamarin.Forms;
//Must use framework to access and work with the text file.
using System.IO;
using System.Reflection;

namespace MMFitnessApp
{
    public partial class FoodDetailsPage : ContentPage
    {
        //Store the objects properties.
        List<FoodItems> foodList = new List<FoodItems>();

        public FoodDetailsPage()
        {
            InitializeComponent();

            //Load food text file and populate the picker.
            LoadFoodFile();
        }


        /// <summary>
        /// Processes the data file and add food items to picker.
        /// </summary>
        private void LoadFoodFile()
        {
            //Allows access to the saved imbedded text file in the solution explorer assembly.
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FoodDetailsPage)).Assembly;

            //Use stream to open up and find text file within the solution explorer.
            Stream stream = assembly.GetManifestResourceStream("MMFitnessApp.food.txt");

            //String array to store each of the food items from the text file.
            string[] foodItem;

            //List of string to hold food names to populate picker.
            List<string> foodNames = new List<string>();


            //Process the food text file. Allows to read each line in the text file.
            using (var reader = new StreamReader(stream))
            {
                //Skips the headers in the food text file.
                reader.ReadLine();

                //To loop through each line and store it in the string array. Read until not at the end of the stream.
                while (!reader.EndOfStream)
                {
               
                    //Read file line for line. Array after each tab.
                    foodItem = reader.ReadLine().Split('\t');

                    //Create a new food with each loop.
                    FoodItems food = new FoodItems(foodItem);

                    //Adding a food name from the foodItems.
                    foodNames.Add(food.FoodName);

                    //Provides a food for the list.
                    foodList.Add(food);
                };
            }

            //Adds the names to the picker
            PckFood.ItemsSource = foodNames;
        }



        /// <summary>
        /// Display results for selected food item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDetails_Clicked(System.Object sender, System.EventArgs e)
        {
            //Validate user has selected a picker option.
            if (PckFood.SelectedIndex > -1)
            {
                //Adds a new instance of a food item.
                FoodItems selectedFood = new FoodItems();

                //Looks at each individual item within the foodList.
                foreach (FoodItems food in foodList)
                {
                    //Check if the food item equals the selected item from the picker.
                    if (food.FoodName == PckFood.SelectedItem.ToString())
                    {
                        //The new instance of the food (selectedFood) equals the one found in the list.
                        selectedFood = food;
                    }
                }

                //Show users results for selected food item with items calegory, measurement, and calories information in a display alert.
                DisplayAlert(selectedFood.FoodName, $"Category: {selectedFood.Category}\n\n" +
                  $"Measurement: {selectedFood.Measurement}\n\n" +
                  $"Calories: {selectedFood.Calories.ToString("n0")}", "Close");
            }

            else
            {
                //User hasn't selected an item, show alert to telling them to select one.
                DisplayAlert("Invalid Input", "Please select a food item first.", "Close");
            }
        }


        /// <summary>
        /// Return users to the main page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void BtnClose_Clicked(System.Object sender, System.EventArgs e)
        {
            //Close the current Food Details Page and return to the Main Page.
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
