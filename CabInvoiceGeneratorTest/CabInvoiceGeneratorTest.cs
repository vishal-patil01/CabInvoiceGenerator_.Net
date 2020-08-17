// <copyright file="CabInvoiceGeneratorTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Test Class To Test Cab Invoice Generator.
    /// </summary>
    public class CabInvoiceGeneratorTest
    {
        /// <summary>
        /// Instance Variable Of <see cref="CabInvoiceGenerator"/> Class.
        /// </summary>
        private CabInvoiceGenerator cabInvoiceGenerator;

        /// <summary>
        /// Setup Method For Initializing Instance of <see cref="CabInvoiceGenerator"/> Class for Test Methods.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        /// <summary>
        /// Test To Calculate Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenTotalFareIsGreaterThanMinimumFare_ShouldReturnTotalFare()
        {
            double distance = 5.0;
            int time = 5;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(55, totalFare);
        }

        /// <summary>
        /// Test To Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_WhenTotalFareIsLessThanMinimumFare_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5.0d, totalFare);
        }

        /// <summary>
        /// Test to get total fare for Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            Rides[] ride = { new Rides(3.0, 5.0), new Rides(2.0, 5.0) };
            double aggregateFare = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            Assert.AreEqual(30.0, aggregateFare);
        }
    }
}