using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsify.Log;
using Parsify.Tokens;

namespace Parsify
{
    /// <summary>
    /// It makes tokens from source
    /// </summary>
    public class Lexer
    {
        public enum ErrorCode
        {
            None,
            UnexpectedToken
        }

        private TokenCollection collection;
        private List<Token> tokens = new List<Token>();

        private string source;

        private int pos;
        private int line;

        /// <summary>
        /// The constructor for the lexer
        /// </summary>
        /// <param name="collection">The collection of availiable tokens</param>
        public Lexer(TokenCollection collection)
        {
            this.collection = collection;
            Logger.Debug("Initialized lexer");
        }

        /// <summary>
        /// Resets the information about the source
        /// </summary>
        public void Reset()
        {
            tokens.Clear();
            pos = -1;
            line = -1;
            Logger.Debug("Resetted lexer");
        }

        /// <summary>
        /// Sets the source for the lexer
        /// </summary>
        /// <param name="source"></param>
        public void SetSource(string source)
        {
            Reset();
            this.source = source.Replace("\r\n", "\n");
            Logger.Debug("Set source in lexer");
        }

        /// <summary>
        /// Gets the token list
        /// </summary>
        /// <returns>The token list</returns>
        public List<Token> GetTokens()
        {
            return tokens;
        }

        /// <summary>
        /// Scans the source for tokens
        /// </summary>
        public ErrorCode Scan()
        {
            while(pos < source.Length && Peek() != -1)
            {
                while (PeekAsChar() != '\n' && char.IsWhiteSpace(PeekAsChar()))
                    Read();

                if (PeekAsChar() == '\n')
                {
                    while (PeekAsChar() == '\n')
                    {
                        Read();
                        line++;
                        tokens.Add(new TokenEOL(line));
                        Logger.Debug("Added token with type: End of line");
                    }
                }
                else if (char.IsLetterOrDigit(PeekAsChar()))
                {
                    ScanIdentifier();
                    Logger.Debug("Scanned identifier");
                }
                else
                {
                    if (collection.ContainsKey(PeekAsChar()))
                    {
                        char key = PeekAsChar();
                        Read();
                        Token token = collection[key];
                        token.Line = line;
                        tokens.Add(token);
                        Logger.Debug("Added token with type: " + token.ToString());
                    }
                    else
                    {
                        Logger.Error("Unexpected token at line " + line);
                        return ErrorCode.UnexpectedToken;
                    }
                }
            }
            tokens.Add(new TokenEOF(line));
            Logger.Debug("Added token with type: End of file");

            return ErrorCode.None;
        }

        /// <summary>
        /// Scans an identifier
        /// </summary>
        /// <param name="add">Add to token list</param>
        /// <returns>The identifier</returns>
        public string ScanIdentifier(bool add = true)
        {
            StringBuilder sbuilder = new StringBuilder();

            while (char.IsLetterOrDigit(PeekAsChar()) || PeekAsChar() == '_' || PeekAsChar() == '-')
                sbuilder = sbuilder.Append(ReadAsChar());

            string identifier = sbuilder.ToString();

            if (add) tokens.Add(new TokenIdentifier(identifier, line));

            return identifier;
        }

        /// <summary>
        /// Returns the next char from the source
        /// or -1 if it is EOF
        /// </summary>
        /// <returns>The char as int</returns>
        public int Peek()
        {
            return pos < source.Length - 1 ? source[pos + 1] : -1;
        }

        /// <summary>
        /// Returns the next char from the source
        /// or -1 if it is EOF
        /// </summary>
        /// <returns>The char</returns>
        public char PeekAsChar()
        {
            if (Peek() != -1)
                return (char)Peek();
            else
                return (char)0;
        }

        /// <summary>
        /// Returns the next char from the source
        /// or -1 if it is EOF and increments position by one.
        /// </summary>
        /// <returns>The char as int</returns>
        public int Read()
        {
            return pos < source.Length - 1 ? source[++pos] : -1;
        }

        /// <summary>
        /// Returns the next char from the source
        /// or (char)0 if it is EOF and increments position by one.
        /// </summary>
        /// <returns>The char</returns>
        public char ReadAsChar()
        {
            if (Peek() != -1)
                return (char)Read();
            else
                return (char)0;
        }

        /// <summary>
        /// Appends the string into the position of the source
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="position">The position</param>
        public void AppendStrAt(string str, int position)
        {
            StringBuilder sbuilder = new StringBuilder();
            sbuilder = sbuilder.Append(source);
            sbuilder = sbuilder.Insert(position, str);
            source = sbuilder.ToString();
        }

    }
}
