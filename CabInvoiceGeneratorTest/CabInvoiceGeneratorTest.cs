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
        /// Time Required For First Ride.
        /// </summary>
        private readonly double firstRideTime = 10;

        /// <summary>
        /// Time Required For Second Ride.
        /// </summary>
        private readonly double secondRideTime = 5;

        /// <summary>
        /// Time Required For Third Ride.
        /// </summary>
        private readonly double thirdRideTime = 0.1;

        /// <summary>
        /// Distance Required For First Ride.
        /// </summary>
        private readonly double firstRideDistance = 20;

        /// <summary>
        /// Distance Required For Second Ride.
        /// </summary>
        private readonly double secondRideDistance = 15;

        /// <summary>
        /// Distance Required For Third Ride.
        /// </summary>
        private readonly double thirdRideDistance = 0.2;

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
            Rides[] ride = { new Rides(this.firstRideDistance, this.firstRideTime, RideCategory.Normal) };
            var invoiceSummary = this.cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(210, invoiceSummary.TotalFare);
        }

        /// <summary>
        /// Test To Calculate Minimum Fare.
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_WhenTotalFareIsLessThanMinimumFare_ShouldReturnMinimumFare()
        {
            Rides[] ride = { new Rides(this.thirdRideDistance, this.thirdRideTime, RideCategory.Normal) };
            var invoice = this.cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(5.0d, invoice.TotalFare);
        }

        /// <summary>
        /// Test Get Total Fare For Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            Rides[] ride = { new Rides(this.firstRideDistance, this.firstRideTime, RideCategory.Normal), new Rides(this.secondRideDistance, this.secondRideDistance, RideCategory.Normal) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(187.5, invoiceSummary.AverageFarePerRide);
        }

        /// <summary>
        /// Test To Get Enhanced Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Rides[] rides = { new Rides(this.firstRideDistance, this.firstRideTime, RideCategory.Normal), new Rides(this.secondRideDistance, this.secondRideTime, RideCategory.Normal) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 365);
            Assert.AreEqual(exceptedInvoiceSummary, invoiceSummary);
        }

        /// <summary>
        /// Test method to check invoice summary of particular user.
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_ShouldReturnUserInvoiceSummary()
        {
            string userId = "vish@xyz.com";
            Rides[] rides = { new Rides(this.firstRideDistance, this.firstRideTime, RideCategory.Normal), new Rides(this.secondRideDistance, this.secondRideTime, RideCategory.Normal) };
            this.cabInvoiceGenerator.AddRideForUser(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 365);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Test To Check Invoice Summary For Multiple Ride With One Premium And One Normal.
        /// </summary>
        [Test]
        public void GivenUserIdAndMultipleRidesWithOnePremiumAndOneNormal_ShouldReturnInvoiceSummary()
        {
            string userId = "xyz@abc.com";
            Rides[] rides = { new Rides(this.firstRideDistance, this.firstRideTime, RideCategory.Premium), new Rides(this.secondRideDistance, this.secondRideTime, RideCategory.Normal) };
            this.cabInvoiceGenerator.AddRideForUser(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 475);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Test To Check Invoice Summary For Multiple Ride With Both Premium.
        /// </summary>
        [Test]
        public void GivenUserIdAndMultiplePremiumRide_ShouldReturnInvoiceSummary()
        {
            string userId = "xyz@abc.com";
            Rides[] rides = { new Rides(this.firstRideDistance, this.firstRideTime, RideCategory.Premium), new Rides(this.secondRideDistance, this.secondRideTime, RideCategory.Premium) };
            this.cabInvoiceGenerator.AddRideForUser(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 555);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }
    }
}