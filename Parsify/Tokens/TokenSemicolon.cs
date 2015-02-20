using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// This token represents a semicolon (";")
    /// </summary>
    public class TokenSemicolon : Token
    {

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public TokenSemicolon(int line) : base(line) { }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenSemicolon() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return ";";
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenSemicolon cls = token as TokenSemicolon;
            return cls != null;
        }

    }
}
