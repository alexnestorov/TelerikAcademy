using System;

class UnicodeCharacters
{
    static void Main()
    {
        char[] text = Console.ReadLine().ToCharArray();
        foreach (var ch in text)
        {
            Console.Write(String.Format("\\u{0}", Convert.ToUInt16(ch).ToString("x4")));
        }
        Console.WriteLine();
    }
}
