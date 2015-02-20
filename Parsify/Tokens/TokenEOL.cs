using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// The token for an end of line
    /// </summary>
    public class TokenEOL : Token
    {

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public TokenEOL(int line) : base(line) { }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenEOL() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return "End of line";
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenEOL cls = token as TokenEOL;
            return cls != null;
        }

    }
}
