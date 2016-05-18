using System;

class StringLength
{
    static void Main()
    {
        string text = Console.ReadLine();
        if (text.Length > 20)
        {
            string phraseToReplace = text.Substring(20, text.Length - 20);
            string replaceText = new string('*', text.Length - 20);
            Console.WriteLine(text.Replace(phraseToReplace, replaceText));
        }
    }
}
