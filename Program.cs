using sa_laptii_lb1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sa_laptii_lb1
{
    class Program
    {
        IEnumerable<Token> Tokenize(string text)
        {
            var table = new Dict();
            var remainingText = text.TrimStart();
            while (remainingText != "")
            {
                var bestMatch =
                   (from pair in table.regexes
                    let tokenType = pair.Key
                    let regex = pair.Value
                    let match = regex.Match(remainingText)
                    let matchLen = match.Length
                    orderby matchLen descending, tokenType
                    select new { tokenType, text = match.Value, matchLen }).First();

                if (bestMatch.matchLen == 0)
                    throw new Exception("Unknown lexeme");

                var token = new Token() { Type = bestMatch.tokenType };
                table.creators[bestMatch.tokenType](bestMatch.text, token);
                yield return token;

                remainingText = remainingText.Substring(bestMatch.matchLen).TrimStart();
            }
        }

        static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadKey();
        }

        void Run()
        {
            //var text1 = "for(var i=0; i>0; i++) var x=x+1";
            //var text2 = "var x = 0; if(x==0) x=8-9;";
            //var text3 = "var x = 0; if (x > 0) x = 1; else x = x + 3 - 0; ";
            //var text4 = "var x = 0; while(x = 0) { var t = 1+3; t++;}";
            var text5 = "int i = -1; do { var i = -2738; i++;} while (i > 0);";

            foreach (var token in Tokenize(text5))
                Console.WriteLine(token.Type);
        }
    }
}

