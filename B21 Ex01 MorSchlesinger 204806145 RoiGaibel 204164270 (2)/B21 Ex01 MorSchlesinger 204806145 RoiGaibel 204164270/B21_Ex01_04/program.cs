using System;
using System.Linq;

// The main class and file name should be called Program.

namespace B21_Ex01_04
{
    class program
    {
        public static void Main()
        {
            string userInput = inputUserString(10);
            char userIntputFirstChar = userInput[0];
            bool inputIsPalindrome = isPalindrome(userInput);

            Console.WriteLine(string.Format("It is {0} that your input is a palindrome,", inputIsPalindrome.ToString()));
            bool inputIsNumber = !Char.IsLetter(userIntputFirstChar);
            if(inputIsNumber)
            {
                bool inputIsMultOfFour = isMultOfFour(userInput);
                Console.WriteLine(string.Format("It is {0} that your input is a multiple of four.", inputIsMultOfFour.ToString()));
            }
            if(!inputIsNumber)
            {
                int numOfCapitalLetters = numOfCapitals(userInput);
                Console.WriteLine(string.Format("your input has {0} Capital letter(s).", numOfCapitalLetters));
            }

        }

        //Bad variable name (should be in the form of i_PascalCase).
        private static string inputUserString(int i_numOfCharacters)
        {
            Console.WriteLine(string.Format("Please enter a {0} character string consisting of only numbers or only english letters", i_numOfCharacters));
            string userInput = Console.ReadLine();
            while((!userInput.All(Char.IsLetter) && !userInput.All(Char.IsDigit)) || userInput.Length != i_numOfCharacters)
            {
                if(userInput.Length != i_numOfCharacters)
                {
                    Console.WriteLine(string.Format("Please make sure that your input is {0} characters long", i_numOfCharacters));
                }
                else
                {
                    Console.WriteLine("Please make sure that your input consists of *only* numbers or *only* english letters.");
                }
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        //  Bad variable name (should be in the form of i_PascalCase).
        private static bool isPalindrome(string i_inputString)
        {
            bool inputIsPalindrome = true;
            int endOfInput = i_inputString.Length;

            if(i_inputString.Length <= 1)  // base case
            {
                inputIsPalindrome = true;
            }
            else if(i_inputString[0] != i_inputString[endOfInput - 1])
            {
                inputIsPalindrome = false;
            }
            else
            {
                isPalindrome(i_inputString.Substring(1, endOfInput - 2));
            }

            return inputIsPalindrome;
        }
        private static bool isMultOfFour(string i_userInput)
        {
            double userInputAsInt = double.Parse(i_userInput);
            bool inputIsMultOfFour = (userInputAsInt % 4 == 0);

            return inputIsMultOfFour;
        }

        private static int numOfCapitals(string i_userInput)
        {
            int numOfCapitalLetters = 0;

            for(int i = 0; i < i_userInput.Length; i++)
            {
                if(Char.IsUpper(i_userInput[i]))
                {
                    numOfCapitalLetters++;
                }
            }

            return numOfCapitalLetters;
        }
    }
}
