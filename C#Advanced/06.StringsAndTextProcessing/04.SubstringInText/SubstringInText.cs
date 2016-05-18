using System;

class SubstringInText
{
    static void Main()
    {
        string randomText = Console.ReadLine().ToLower();
        string match = "we";
        int count = 0;
        for (int i = 0; i < randomText.Length - 1; i++)
        {
            string part = randomText.Substring(i, 2);
            if (part.Equals(match))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
