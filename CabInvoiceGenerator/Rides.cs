// <copyright file="Rides.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Class To Store Ride Information.
    /// </summary>
    public class Rides
    {
        /// <summary>
        /// store Ride Distance.
        /// </summary>
        public double RideDistance;

        /// <summary>
        /// store Ride Time.
        /// </summary>
        public double RideTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rides"/> class.
        /// </summary>
        /// <param name="rideDistance">Total Ride Distance.</param>
        /// <param name="rideTime">Total Ride Time.</param>
        public Rides(double rideDistance, double rideTime)
        {
            this.RideDistance = rideDistance;
            this.RideTime = rideTime;
        }
    }
}
