using System;
using System.Text;

// The main class and file name should be called Program.

namespace B21_Ex01_02
{
    public class program
    {
        public static void Main()
        {
            int sandClockHeight = 5;  // desired height of sand clock
            int constSandClockHeight = sandClockHeight; // used as a constant to remember

            BuildSandClock(sandClockHeight, constSandClockHeight);
        }

        // You should have used StringBuilder here
        // You should have used StringBuilder to build entire hourglass instead of build each line and printing it separately
        public static void BuildSandClock(int i_sandClockHeight, int i_constSandClockHeight)
        {
            int numOfSpaces = (i_constSandClockHeight - i_sandClockHeight) / 2;
            string currentOutputString = buildSandClockRow(numOfSpaces, i_sandClockHeight);

            if (i_sandClockHeight == 1)   // after we've reached the end of the first half
            {
                Console.WriteLine(currentOutputString);

                return;
            }
            else
            {
                Console.WriteLine(currentOutputString);
                BuildSandClock(i_sandClockHeight - 2, i_constSandClockHeight);
                Console.WriteLine(currentOutputString);
            }
        }

        private static string buildSandClockRow(int i_numOfSpaces, int i_numOfStars)
        {
            StringBuilder sandClockRowBuilder = new StringBuilder(i_numOfStars);
            sandClockRowBuilder.Append(new string(' ', i_numOfSpaces));
            sandClockRowBuilder.Append(new string('*', i_numOfStars));
            //currentOutputString = string.Format("{0}{1}", currentOutputRow);

            return sandClockRowBuilder.ToString();
        }
    }
}
