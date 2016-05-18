using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractSentences
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] sentences = text.Split('.', '?', '!')
                                 .ToArray();
        string matchWord = Console.ReadLine();
        List<string> filteredSentences = new List<string>();
        for (int i = 0; i < sentences.Length; i++)
        {
            var words = sentences[i].Split(' ').ToList();
            var isMatchWord = words.Where(x => x == matchWord);
            if (isMatchWord.Count() > 0)
            {
                filteredSentences.Add(sentences[i].TrimStart());
            }
        }
        Console.WriteLine(string.Join(". ", filteredSentences)+ ".");
    }
}
