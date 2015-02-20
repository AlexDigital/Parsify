using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// This token represents an identifier
    /// </summary>
    public class TokenIdentifier : Token
    {
        public string Value { get; private set; }

        /// <summary>
        /// Constructor with a value and a line number
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="line">The line</param>
        public TokenIdentifier(string value, int line)
            : base(line)
        {
            this.Value = value;
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenIdentifier() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return Value;
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenIdentifier cls = token as TokenIdentifier;
            return cls != null;
        }

    }
}
