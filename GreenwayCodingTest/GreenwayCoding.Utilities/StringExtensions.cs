using System;
using System.Collections.Generic;

namespace GreenwayCoding.Utilities
{
    public static class StringExtensions
    {
        public static string ToSanitizedContent(this string input,List<string> replaceContentCollection,string newContent)
        {
            if(!string.IsNullOrWhiteSpace(input))
            {
                foreach (var replaceContent in replaceContentCollection)
                {
                    input = input.Replace($"{replaceContent}", $"{newContent}");

                }
                return input;
            }
            return input;
        }
    }
}
