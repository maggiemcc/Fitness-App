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
namespace MMFitnessApp
{
    public class FoodItems
    {
        //Get objects/attributes to store for food.
        public string Category { get; set; }
        public string FoodName { get; set; }
        public string Measurement { get; set; }
        public int Calories { get; set; }
        

        public FoodItems()
        {
            //Set default value to each attribute.
            Category = "";
            FoodName = "";
            Measurement = "";
            Calories = 0;
        }

        /// <summary>
        /// Parameterized constructor for food items.
        /// </summary>
        /// <param name="foodArray"></param>
        public FoodItems(string[] foodArray)
        {
            //Add each object in order of the string array.
            Category = foodArray[0];
            FoodName = foodArray[1];
            Measurement = foodArray[2];
            Calories = int.Parse(foodArray[3]);
        }
    }
}
