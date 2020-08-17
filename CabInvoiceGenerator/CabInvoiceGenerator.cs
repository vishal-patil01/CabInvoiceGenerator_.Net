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

        /// <summary>
        /// Function to Calculate Total Fare.
        /// </summary>
        /// <param name="distance">Total Distance.</param>
        /// <param name="time">Total Time.</param>
        /// <returns>Total Fare.</returns>
        public double CalculateFare(double distance, double time)
        {
            double totalFare = 0.0;
            totalFare = (distance * CostPerKilometer) + (time * CostPerMinute);
            return Math.Max(totalFare, MinimumFare);
        }

        /// <summary>
        ///  Function to Calculate Total Fare For Multiple Ride.
        /// </summary>
        /// <param name="rides">Array Of Ride Object.</param>
        /// <returns>Total Fare.</returns>
        public double GetMultipleRideFare(Rides[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Rides ride in rides)
            {
                totalRideFare += this.CalculateFare(ride.RideDistance, ride.RideTime);
            }

            return totalRideFare / rides.Length;
        }
    }
}
