using sa_laptii_lb1.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace sa_laptii_lb1.Helpers
{
    public class Dict
    {
        public Dictionary<TokenEnum, Regex> regexes = new Dictionary<TokenEnum, Regex>()
        {
            [TokenEnum.Comparison] = new Regex(@"^(>=?|<=?|==)"),
            [TokenEnum.Punct] = new Regex(@"^[,)(}{;]"),
            [TokenEnum.If] = new Regex(@"^if"),
            [TokenEnum.Else] = new Regex(@"^else"),
            [TokenEnum.Identifier] = new Regex(@"^[a-zA-Z_][a-zA-Z_0-9]*"),
            [TokenEnum.NumLiteral] = new Regex(@"^[0-9]+(\.[0-9]+)?"),
            [TokenEnum.Equal] = new Regex(@"^(?<!=)=(?!=)"),
            [TokenEnum.Plus] = new Regex(@"^\+"),
            [TokenEnum.Minus] = new Regex(@"^\-"),
            [TokenEnum.PossesiveQuant] = new Regex(@"^\++"),

        };

        public Dictionary<TokenEnum, Action<string, Token>> creators =
        new Dictionary<TokenEnum, Action<string, Token>>()
        {
            [TokenEnum.Comparison] = (s, token) => { },
            [TokenEnum.Punct] = (s, token) => { },
            [TokenEnum.If] = (s, token) => { },
            [TokenEnum.Else] = (s, token) => { },
            [TokenEnum.Identifier] = (s, token) => { },
            [TokenEnum.NumLiteral] = (s, token) => token.NumericValue = double.Parse(s),
            [TokenEnum.Equal] = (s, token) => { },
            [TokenEnum.Plus] = (s, token) => { },
            [TokenEnum.Minus] = (s, token) => { },
            [TokenEnum.PossesiveQuant] = (s, token) => { }
        };
    }
}
