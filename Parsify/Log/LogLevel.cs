using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Log
{
    /// <summary>
    /// The verbosity level of the logger
    /// </summary>
    public enum VerbosityLevel
    {
        /// <summary>
        /// Silent mode
        /// </summary>
        Silent = 0,
        /// <summary>
        /// Error only mode
        /// </summary>
        ErrorOnly = 1,
        /// <summary>
        /// Warning mode
        /// </summary>
        Warnings = 2,
        /// <summary>
        /// Basic mode
        /// </summary>
        Basic = 3,
        /// <summary>
        /// Debug mode
        /// </summary>
        Debug = 4
    }

    /// <summary>
    /// Storage class for the verbosity
    /// </summary>
    public static class Verbosity
    {
        /// <summary>
        /// The current verbosity
        /// </summary>
        public static VerbosityLevel Verb { get; set; }
    }
}
