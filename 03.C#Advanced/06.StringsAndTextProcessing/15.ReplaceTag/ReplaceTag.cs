using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main(string[] args)
    {
        string htmlText = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        // The input is finished with "end"
        while (htmlText != "end")
        {
            string pattern = @"<a href=(""|')([a-zA-Z0-9/\:\. ]+)\1>([a-zA-Z0-9 ]+)<\/a>";
            string replacement = @"[URL href=$2]$3[/URL]";
            Regex rgx = new Regex(pattern);
            result.AppendLine(Regex.Replace(htmlText, pattern, replacement)
                                   .TrimStart('"')
                                   .TrimEnd('"'));
            htmlText = Console.ReadLine();
        }
        Console.Write(result);
    }
}
