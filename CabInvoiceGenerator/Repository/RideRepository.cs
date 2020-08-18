// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains Data Regarding Users And Rides.
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Dictionary To Store Ride Details With UserId.
        /// </summary>
        private readonly Dictionary<string, List<Rides>> userRides;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// Initialize userRides Dictionary.
        /// </summary>
        public RideRepository() => this.userRides = new Dictionary<string, List<Rides>>();

        /// <summary>
        /// Function To Add UserId and Rides List Into Dictionary.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="rides">Array Of Ride Object.</param>
        public void AddRides(string userId, Rides[] rides)
        {
            bool isUserIdExists = this.userRides.ContainsKey(userId);

            if (isUserIdExists)
            {
                List<Rides> lists = this.userRides[userId];
                lists.AddRange(rides);
                this.userRides[userId] = lists;
            }
            else
            {
                this.userRides.Add(userId, new List<Rides>(rides));
            }
        }

        /// <summary>
        /// Function To Get Ride Details According To User Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Array Of Rides.</returns>
        public Rides[] GetRides(string userId) => this.userRides[userId].ToArray();
    }
}
