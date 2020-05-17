//Name: Maggie McCausland
//Class: (INFO 1200)
//Section: (001)
//Professor: (Crandall)
//Date: 4/04/2020
//Project #: Project8B
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.IO;
using System.Linq;

namespace MMFitnessApp
{
    public partial class MyWater : ContentPage
    {
        //Set Daily Water Goal to value of 8 glasses a day.
        int waterGoal = 7;
        int addWater = 0;

        //Set documents, fileName, fileStored to empty string.
        string documents = "";
        string fileName = "";
        string fileStored = "";


        public MyWater()
        {
            InitializeComponent();

            //Display current date in date label.
            string today = DateTime.Now.ToString("d");
            LblDate.Text = $"Date: {today}";

            //Replace forward slash with underscore.
            string fileDate = today.Replace('/', '_');

            //Load & pass the fileDate as a parameter.
            LoadSavedFile(fileDate);
        }


        /// <summary>
        /// Get the file path & name and then combine to store the file.
        /// </summary>
        /// <param name="fileDate">Set fileDate as user's file for today.</param>
        private void LoadSavedFile(string fileDate)
        {
            //Get file path & where to store Water.
            documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Get file name.
            fileName = $"{fileDate}water.txt";

            //Combine documents and fileName
            fileStored = Path.Combine(documents, fileName);

            //If the file exists
            if (File.Exists(fileStored))
            {
                //The file exists, read the file
                addWater = int.Parse(File.ReadAllLines(fileStored).Last().ToString());

                //Increase water count and images by one.
                for (int i = 0; i < addWater; i++)
                {
                    //Add a new water image each time button is pushed.
                    Image image = new Image { Source = "Water.jpg" };
                    SLWater.Children.Add(image);

                    //Display water count in add water label.
                    LblAddWater.Text = $"Water Count: {addWater}";
                }
            }

            else
            {
                //File Doesn't exist, create the file
                File.WriteAllText(fileStored, addWater.ToString());
            }
        }


            /// <summary>
            /// Increase water by one with each press and display results.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BtnAddWater_Clicked(System.Object sender, System.EventArgs e)
            {
            //If the addwater is less than/equal to the water goal.
            if (addWater <= waterGoal)
            {
                //Increase water
                addWater ++;

                //Display water count in add water label.
                LblAddWater.Text = $"Water Count: {addWater}";

                //Add a new image with each time the AddWater button is pushed.
                Image image = new Image { Source = "Water.jpg" };
                SLWater.Children.Add(image);

                //Write the file.
                File.WriteAllText(fileStored, addWater.ToString());

                //Display the results.
                LblAddWater.Text = addWater.ToString();
            }

            else
            {
                //Display alert that user has reached goal of 8 waters.
                DisplayAlert("Met Water Goal", "You have reached your water goal of 8 today.", "Close");
            }

            }

           

        /// <summary>
        /// Close the MyWaterPage and return users to the main page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Clicked(System.Object sender, System.EventArgs e)
        {
            // Close the current BMR Page and return to the Main Page
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
