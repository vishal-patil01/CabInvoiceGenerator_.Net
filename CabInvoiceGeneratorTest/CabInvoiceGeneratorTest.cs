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
        /// Test Get Total Fare For Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            Rides[] ride = { new Rides(3.0, 5.0), new Rides(2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(30.0, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test To Get Enhanced Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Rides[] rides = { new Rides(25.12, 40), new Rides(12.39, 25) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary summary = new InvoiceSummary(2, 440.1);
            Assert.AreEqual(summary, invoiceSummary);
        }
    }
}