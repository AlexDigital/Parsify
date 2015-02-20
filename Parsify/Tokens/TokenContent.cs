using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsify.Tokens
{

    /// <summary>
    /// Stores content in an token for use in the tokenizer
    /// </summary>
    public class TokenContent : Token
    {
        /// <summary>
        /// The content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Constructor with content and line
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="line">The line</param>
        public TokenContent(string content, int line)
            : base(line)
        {
            this.Content = content;
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public TokenContent() : base() { }

        /// <summary>
        /// The representation of this token
        /// </summary>
        /// <returns>The token</returns>
        public override string ToString()
        {
            return this.Content;
        }

        public static bool IsAssignableFrom(Token token)
        {
            TokenContent cls = token as TokenContent;
            return cls != null;
        }
    }
}
