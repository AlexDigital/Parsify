using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsify;
using Parsify.Log;
using Parsify.Tokens;

namespace ParsifyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Verbosity.Verb = VerbosityLevel.ErrorOnly;

            string csv = "test1,value1\n" +
                         "test2,value2\n" +
                         "test3,value3\n" +
                         "test4,value4\n" +
                         "test5,value5";

            TokenCollection avtokens = new TokenCollection();
            avtokens.Add(',', new TokenComma());

            Lexer lexer = new Lexer(avtokens);
            lexer.SetSource(csv);
            Lexer.ErrorCode error = lexer.Scan();

            if (error == Lexer.ErrorCode.UnexpectedToken)
            {
                Console.WriteLine("An error has been encountered, press any key to exit ...");
                Console.ReadKey();
                return;
            }
            Dictionary<string, string> csvdata = new Dictionary<string, string>();

            int tokeninline = 1;

            string key = "";
            string value = "";
            foreach (Token token in lexer.GetTokens())
            {

                if (TokenEOL.IsAssignableFrom(token) || TokenEOF.IsAssignableFrom(token))
                {
                    tokeninline = 1;
                    if(!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value)) 
                        csvdata.Add(key, value);
                    if (TokenEOL.IsAssignableFrom(token)) continue;
                    if (TokenEOF.IsAssignableFrom(token)) break;
                }

                switch (tokeninline)
                {
                    case 1:
                        if (!TokenIdentifier.IsAssignableFrom(token))
                        {
                            Logger.Error("Debug error: Unexpected token at line " + token.Line);
                            Console.ReadKey();
                        }
                        TokenIdentifier keyidentifier = token as TokenIdentifier;
                        key = keyidentifier.Value;
                        break;
                    case 2:
                        if (!TokenComma.IsAssignableFrom(token))
                        {
                            Logger.Error("Debug error: Unexpected token at line " + token.Line);
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (!TokenIdentifier.IsAssignableFrom(token))
                        {
                            Logger.Error("Debug error: Unexpected token at line " + token.Line);
                            Console.ReadKey();
                        }
                        TokenIdentifier valueidentifier = token as TokenIdentifier;
                        value = valueidentifier.Value;
                        break;
                }

                tokeninline++;
            }

            foreach(KeyValuePair<string, string> pair in csvdata)
            {
                Console.WriteLine("Key: " + pair.Key + " - Value: " + pair.Value);
            }

            Console.ReadKey();
        }
    }
}

