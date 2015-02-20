using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{
    /// <summary>
    /// This token represents a closing parenthesis (")")
    /// </summary>
    public class TokenParClosing : Token
    {

        /// <summary>
        /// Constructor with line number
        /// </summary>
        /// <param name="line">The line</param>
        public TokenParClosing(int line) : base(line) { }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenParClosing() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return ")";
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenParClosing cls = token as TokenParClosing;
            return cls != null;
        }

    }
}
