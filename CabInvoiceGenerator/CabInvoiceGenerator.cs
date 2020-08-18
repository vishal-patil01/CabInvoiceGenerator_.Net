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
        private readonly RideRepository rideRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceGenerator"/> class.
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public CabInvoiceGenerator() => this.rideRepository = new RideRepository();

        /// <summary>
        ///  Function to Calculate Total Fare For Multiple Ride.
        /// </summary>
        /// <param name="rides">Array Of Ride Object.</param>
        /// <returns>Total Fare.</returns>
        public InvoiceSummary CalculateFare(Rides[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Rides ride in rides)
            {
                totalRideFare += ride.Category.CalculateCategoryWiseFare(ride);
            }

            return new InvoiceSummary(rides.Length, totalRideFare);
        }

        /// <summary>
        /// Add Rides For Specific User.
        /// </summary>
        /// <param name="userID">User Id.</param>
        /// <param name="rides">Array Of Rides.</param>
        public void AddRideForUser(string userID, Rides[] rides) => this.rideRepository.AddRides(userID, rides);

        /// <summary>
        /// Generate Invoice Summary For Specific User.
        /// </summary>
        /// <param name="userID">User Id.</param>
        /// <returns>Invoice Summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userID) => this.CalculateFare(this.rideRepository.GetRides(userID));
    }
}
