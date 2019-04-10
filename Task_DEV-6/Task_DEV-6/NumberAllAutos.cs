﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays count of all auto.
    /// </summary>
    public class NumberAllAutos
    {
        List<Auto> Cars { get; }

        /// <summary>
        /// Constructor of NumberAllAutos.
        /// </summary>
        /// <param name="autos"></param>
        public NumberAllAutos(List<Auto> autos) => Cars = autos;

        /// <summary>
        /// Method returns number of all autos.
        /// </summary>
        /// <returns>number of all autos</returns>
        public int GetNumberAllAutos() => Cars.Sum(t => t.Number);

        /// <summary>
        /// Method displays information about number of all autos.
        /// </summary>
        public void DisplayNumberAllCars() => Console.WriteLine(
            GetNumberAllAutos() == 0 
            ? "The XML file hasn't autos." 
            : $"Number of all autos is {GetNumberAllAutos()}");
    }
}