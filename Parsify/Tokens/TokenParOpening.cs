using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// This token represents a opening parenthesis ("(")
    /// </summary>
    public class TokenParOpening : Token
    {

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public TokenParOpening(int line) : base(line) { }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenParOpening() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return "(";
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenParOpening cls = token as TokenParOpening;
            return cls != null;
        }

    }
}
