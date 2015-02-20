using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// This token represents a comma (",")
    /// </summary>
    public class TokenComma : Token
    {

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public TokenComma(int line) : base(line) { }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenComma() : base() { }


        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return ",";
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenComma cls = token as TokenComma;
            return cls != null;
        }

    }
}
