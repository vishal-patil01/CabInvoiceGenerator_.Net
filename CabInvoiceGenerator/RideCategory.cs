// <copyright file="RideCategory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Provide Different Category For Ride And Calculate Fare On Category.
    /// </summary>
    public class RideCategory
    {
        /// <summary>
        /// Ride Of Premium Type.
        /// </summary>
        public static readonly RideCategory Premium = new RideCategory(15.0, 2.0, 20.0);

        /// <summary>
        /// Ride of Normal Type.
        /// </summary>
        public static readonly RideCategory Normal = new RideCategory(10.0, 1.0, 5.0);

        /// <summary>
        /// Initializes a new instance of the <see cref="RideCategory"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        /// <param name="costPerKilometer">Value Of Cost Per Kilometer.</param>
        /// <param name="costPerMinute">Value Of Cost Per Minute.</param>
        /// <param name="minimumFare">Value Of Minimum Fare.</param>
        public RideCategory(double costPerKilometer, double costPerMinute, double minimumFare)
        {
            this.CostPerKilometer = costPerKilometer;
            this.CostPerMinute = costPerMinute;
            this.MinimumFare = minimumFare;
        }

        /// <summary>
        /// cost Required For Per Kilometer.
        /// </summary>
        public double CostPerKilometer;

        /// <summary>
        ///  cost Required For Per Minutes.
        /// </summary>
        public double CostPerMinute;

        /// <summary>
        ///  minimum Cost Required For Ride.
        /// </summary>
        public double MinimumFare;

        /// <summary>
        /// Function To Get Total Fare Of Cab Ride Based On Ride Category.
        /// </summary>
        /// <param name="ride">Instance Of Rides.</param>
        /// <returns>Total Fare.</returns>
        public double CalculateCategoryWiseFare(Rides ride)
        {
            double totalFare = (ride.RideDistance * this.CostPerKilometer) + (ride.RideTime * this.CostPerMinute);
            return Math.Max(totalFare, this.MinimumFare);
        }
    }
}
