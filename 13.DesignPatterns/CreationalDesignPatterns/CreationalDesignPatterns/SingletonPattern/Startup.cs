using System;

namespace SingletonPattern
{
   public class Startup
    {
       public static void Main()
        {
            var commandManager = CommandManager.GetInstance;

            Console.WriteLine(commandManager.ToString());

            commandManager = CommandManager.GetInstance;
        }
    }
}
