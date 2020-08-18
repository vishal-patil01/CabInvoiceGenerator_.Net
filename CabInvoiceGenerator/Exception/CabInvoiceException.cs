// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Description: Custom Exception Implementation For CabInvoiceException.
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="message">Exception Message.</param>
        /// <param name="type">Exception Type.</param>
        public CabInvoiceException(string message,CabInvoiceExceptionType type)
            : base(message)
        {
            this.ExceptionType = type;
        }

        /// <summary>
        /// Description: Enum For Define Custom Exception Type For CabInvoiceException.
        /// </summary>

        public enum CabInvoiceExceptionType
        {
            INVALID_USERID,
        }

        public CabInvoiceExceptionType ExceptionType { get; set; }
    }
}
