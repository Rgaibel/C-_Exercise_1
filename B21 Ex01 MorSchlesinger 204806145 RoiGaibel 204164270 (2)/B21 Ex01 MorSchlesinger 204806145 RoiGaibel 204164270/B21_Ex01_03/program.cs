using System;

// The main class and file name should be called Program.


// The program does not cope properly with invalid input, what about negative numbers?

namespace B21_Ex01_03
{
    class program
    {
        public static void Main()
        {
            Console.WriteLine("Please tell me the height of your desired sand clock");
            int heightOfSandClock = inputSandClockHeight();

            B21_Ex01_02.program.BuildSandClock(heightOfSandClock, heightOfSandClock);
        }

        private static int inputSandClockHeight()
        {
            string heightOfSandClockString = Console.ReadLine();
            int heightOfSandClockInt;

            while (!int.TryParse(heightOfSandClockString, out heightOfSandClockInt))
            {
                Console.WriteLine("Please input a valid integer.");
                heightOfSandClockString = Console.ReadLine();
            }
            if (heightOfSandClockInt % 2 == 0)
            {
                heightOfSandClockInt += 1;
            }

            return heightOfSandClockInt;
        }
    }
}
