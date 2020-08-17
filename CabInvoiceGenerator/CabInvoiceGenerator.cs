// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Main Class To Generate Cab Invoice.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static readonly double CostPerKilometer = 10.0;
        private static readonly double CostPerMinute = 1.0;
        private static readonly double MinimumFare = 5.0;
        private double totalFare = 0.0;

        /// <summary>
        /// Function to Calculate Total Fare.
        /// </summary>
        /// <param name="distance">Total Distance.</param>
        /// <param name="time">Total Time.</param>
        /// <returns>Total Fare.</returns>
        public double CalculateFare(double distance, double time)
        {
            this.totalFare = (distance * CostPerKilometer) + (time * CostPerMinute);
            return Math.Max(this.totalFare, MinimumFare);
        }
    }
}
