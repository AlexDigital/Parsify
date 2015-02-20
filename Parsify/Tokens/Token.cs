using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{

    /// <summary>
    /// This is the base class for all tokens
    /// </summary>
    public abstract class Token
    {
        /// <summary>
        /// The line number
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public Token(int line)
        {
            this.Line = line;
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Token() { }

    }

}
