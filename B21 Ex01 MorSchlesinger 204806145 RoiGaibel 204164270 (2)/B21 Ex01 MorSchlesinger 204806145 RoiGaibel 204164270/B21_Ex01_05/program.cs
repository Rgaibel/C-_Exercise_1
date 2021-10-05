using System;
using System.Linq;

// The main class and file name should be called Program.

namespace B21_Ex01_05
{
    class program
    {
        public static void Main()
        {
            string userInput = inputUserString(6);
            string[] outputArgs = new string[4];
            outputArgs[0] = getLargestDigit(userInput);
            outputArgs[1] = getSmallestDigit(userInput);
            outputArgs[2] = getNumOfDigitsDivisibleByThree(userInput);
            outputArgs[3] = getNumOfDigitsGrThanUnitDigit(userInput);
            printOutput(outputArgs);

        }

        private static void printOutput(string[] i_outputArgs)
        {
            string outputString = string.Format(
@"The largest digit in your input is *{0}*.
The smallest digit in your input is *{1}*.
There are *{2}* digits in your input that are a multiple of 3.
The number of digits that are bigger than the units digit in your input is *{3}*", i_outputArgs);

            Console.WriteLine(outputString);
        }

        //  Bad variable name (should be in the form of i_PascalCase).
        private static string inputUserString(int i_numOfCharacters)
        {
            Console.WriteLine("Please input a number consisting of 6 digits");
            string userInput = Console.ReadLine();

            while(!userInput.All(Char.IsDigit) || userInput.Length != i_numOfCharacters)
            {
                if(userInput.Length != i_numOfCharacters)
                {
                    Console.WriteLine(string.Format("Please make sure that your input is {0} characters long", i_numOfCharacters));
                }
                else
                {
                    Console.WriteLine("Please make sure that your input consists of *only* numbers.");
                }
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static string getLargestDigit(string i_digitString)
        {
            char maxDigit = '0';

            foreach(char digit in i_digitString)            {
                if(digit > maxDigit)
                {
                    maxDigit = digit;
                }
            }

            return maxDigit.ToString();
        }

        private static string getSmallestDigit(string i_digitString)
        {
            char minDigit = '9';

            foreach(char digit in i_digitString)
            {
                if(digit < minDigit)
                {
                    minDigit = digit;
                }
            }

            return minDigit.ToString();
        }
        private static string getNumOfDigitsDivisibleByThree(string i_digitString)
        {
            char numOfMultThree = '0';
            int digitAsInt;

            foreach(char digit in i_digitString)
            {
                digitAsInt = int.Parse(digit.ToString());
                if(digitAsInt % 3 == 0)
                {
                    numOfMultThree++;
                }
            }

            return numOfMultThree.ToString();
        }

        private static string getNumOfDigitsGrThanUnitDigit(string i_digitString)
        {
            char numOfDigitsGrThenUnitDigit = '0';
            char unitDigit = i_digitString[i_digitString.Length - 1];

            for(int i = 0; i < i_digitString.Length - 1; i++)
            {
                if(i_digitString[i] > unitDigit)
                {
                    numOfDigitsGrThenUnitDigit++;
                }
            }

            return numOfDigitsGrThenUnitDigit.ToString();
        }
    }
}
