namespace MobileDeviceCharacteristics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MobileDevice
    {
        static void Main()
        {
            CallHistoryTest.CallHistory();

            // Display IPhone6S information, which is declared as static property in class GSM.
            Console.WriteLine("----------------------");
            GSM iPhone = new GSM();
            Console.WriteLine(iPhone.IPhone6S);

            // Second phone information.
            Console.WriteLine("----------------------");
            Battery liIon = new Battery("Li-Ion", 6, 3, BatteryType.LiIon);
            Display veryLargeDisplay = new Display(7.1, 64000000);
            GSM mySisterPhone = new GSM("Samsung Galaxy S3", "Samsung", 800, "Gergana Georgieva", liIon, veryLargeDisplay);

            Console.WriteLine("My sister's phone characteristics:");
            Console.WriteLine(mySisterPhone.ToString());

            
        }
    }
}