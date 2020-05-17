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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MMFitnessApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Today's Date
        /// </summary>

        public MainPage()
        {
            InitializeComponent();

            // Will display today's date on the home/main page.
            lblDate.Text = DateTime.Now.ToString("d");
        }



        /// <summary>
        /// Display pop-up welcome message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnWelcome_Clicked(System.Object sender, System.EventArgs e)
        {
            // Welcome button brings up pop-up window for welcome message that users can close after read.
            DisplayAlert("Welcome to your fitness app!", "You can do anything!", "Close");
        }


        /// <summary>
        /// Display user fitness profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnProfile_Clicked(System.Object sender, System.EventArgs e)
        {
            //My Profile Button takes users from main page to profile page by "pushing" the MyProfilePage ontop of the main.
            Navigation.PushModalAsync(new MyProfilePage());
        }


        /// <summary>
        /// Display user's BMR page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnBmr_Clicked(System.Object sender, System.EventArgs e)
        {
            //My BMR Button takes users from main page to BMR page by "pushing" the MyBMRPage ontop of the main.
            Navigation.PushModalAsync(new MyBMRPage());
        }


        /// <summary>
        /// Display simple timer page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

       private void btnTimer_Clicked(System.Object sender, System.EventArgs e)
        {
            //My simple timer button will take users from the main page to the timer page by "pushing" the MyBMRPage ontop of the main.
            Navigation.PushModalAsync(new MyTimerPage());
        }


        /// <summary>
        /// Display user's water page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMyWater_Clicked(System.Object sender, System.EventArgs e)
        {
            //My Water button will take users from the main page to the My Water page by "pushing" the MyWaterPage ontop of the main.
            Navigation.PushModalAsync(new MyWater());
        }

        /// <summary>
        /// Display Food details page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFood_Clicked(System.Object sender, System.EventArgs e)
        {
            //The Food Details button will take users from the main page to the Food Details page by "pushing" the FoodDetailsPage ontop of the main.
            Navigation.PushModalAsync(new FoodDetailsPage());
        }
    }
}
