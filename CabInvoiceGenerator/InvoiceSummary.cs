// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Class To Generate Proper Invoice Summary.
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">Total Number Of Rides.</param>
        /// <param name="totalFare">Total Fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.NumberOfRides = numberOfRides;
            this.TotalFare = totalFare;
            this.AverageFarePerRide = this.TotalFare / this.NumberOfRides;
        }

        /// <summary>
        /// Gets or sets total Number Of Rides.
        /// </summary>
        public int NumberOfRides { get; set; }

        /// <summary>
        /// Gets or sets total Cost.
        /// </summary>
        public double TotalFare { get; set; }

        /// <summary>
        /// Gets or sets average Cost For Multiple Ride.
        /// </summary>
        public double AverageFarePerRide { get; set; }

        /// <summary>
        /// Override equals method.
        /// </summary>
        /// <param name="obj">object of <see cref="InvoiceSummary"/>Class.</param>
        /// <returns>True If Values Are Same.</returns>
        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   this.NumberOfRides == summary.NumberOfRides &&
                   this.TotalFare == summary.TotalFare &&
                   this.AverageFarePerRide == summary.AverageFarePerRide;
        }

        /// <summary>
        /// Override HashCode Method.
        /// </summary>
        /// <returns>Return Hash Code Value.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumberOfRides, this.TotalFare, this.AverageFarePerRide);
        }
    }
}
