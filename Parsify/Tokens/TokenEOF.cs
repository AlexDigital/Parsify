using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// The token for an end of file
    /// </summary>
    public class TokenEOF : Token
    {

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public TokenEOF(int line) : base(line) { }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenEOF() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return "End of file";
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenEOF cls = token as TokenEOF;
            return cls != null;
        }

    }
}
