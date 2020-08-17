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
        /// Craete Test For Calculate Total Fare.
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
        /// Craete Test For Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_WhenTotalFareIsLessThanMinimumFare_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5.0d, totalFare);
        }
    }
}