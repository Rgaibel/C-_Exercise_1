using System;
using System.Collections.Generic;
using System.Linq;


//The main class and file name should be called Program.



// The explanation for the file being a PE is lacking. The file is a PE because it is a .NET assembly that can be executed.
// The explanation for the file being an assembly is lacking. The file is an assembly because it can be analysed by ILDASM.

namespace B21_Ex01_01
{
    class program
    {
        public static void Main()
        {
            analyzeBinaryInputs(3);
        }

        private static void analyzeBinaryInputs(int i_numOfBinaryInputs)
        {
            string welcomeMessage = string.Format("Please write {0} positive integers in binary format, 7 digits each, separated by 'enter' hits (after each integer, hit the 'enter' key", i_numOfBinaryInputs);
            Console.WriteLine(welcomeMessage);
            string[] binaryInputs = inputBinary(i_numOfBinaryInputs);       // save users inputs
            int[] decimalOutputs = new int[i_numOfBinaryInputs];            // for when we need the decimal representation of the inputs
            string[] decimalOutputArgs = new string[i_numOfBinaryInputs];   // to be used for output string.Format
            string[] outputArgs = new string[7];                            // all outputs combined to be used for string.Format

            for (int i = 0; i < i_numOfBinaryInputs; i++)                   // fill decimalOutputs array with decimal representation of Binary Inputs and get string representation of these outputs
            {
                decimalOutputs[i] = binaryToDecimal(binaryInputs[i]);
                decimalOutputArgs[i] = decimalOutputs[i].ToString();
            }
            outputArgs[0] = string.Join(", ", decimalOutputArgs);
            // create variables to hold each desired outputs and fill outputArgs to be used for string.format in Console.WriteLine()
            IDictionary<string, float> averageBits = getAverageBits(binaryInputs);
            outputArgs[1] = averageBits["averageNumOfOnes"].ToString();
            outputArgs[2] = averageBits["averageNumOfZeros"].ToString();
            outputArgs[3] = PowersOfTwo(decimalOutputs);
            outputArgs[4] = MonotoneIncreasing(decimalOutputs);
            outputArgs[5] = decimalOutputs.Max().ToString();
            outputArgs[6] = decimalOutputs.Min().ToString();
            printOutput(outputArgs);
            
        }

        // Bad variable name (should be in the form of i_PascalCase).
        private static void printOutput(string[] i_outputArgs)
        {
            string outputString = string.Format(
@"These are your binary inputs as decimal outputs: {0}
The average number of one digit bits you input is {1}
The average number of zeros digit bits you input is {2}
The number of integers that are a power of 2 from your input is {3}
The number of integers that are monotonically increasing from your input is {4}
The Greatest number that you input is {5}
The Greatest number that you input is {6}", i_outputArgs);

            Console.WriteLine(outputString);
        }

        // Bad variable name (should be in the form of i_PascalCase).
        private static string[] inputBinary(int i_numOfInputs)
        {
            string[] binaryInputs = new string[i_numOfInputs];

            for (int i = 0; i < i_numOfInputs; i++)
            {
                binaryInputs[i] = Console.ReadLine();
                if (binaryInputs[i].Length != 7)
                {
                    Console.WriteLine("try that one again. Please make sure your input is 7 digits long");
                    --i;    // we need to retry this input so we decrement i
                    continue;
                }
                foreach (char binaryDigit in binaryInputs[i])
                {
                    if (binaryDigit != '1' && binaryDigit != '0')
                    {
                        Console.WriteLine("try that one again. Please make sure your input is in binary format");
                        --i;    // we need to retry this input so we decrement i
                        break;
                    }
                }
            }

            return binaryInputs;
        }

        private static int binaryToDecimal(string i_binaryInput)
        {
            int decimalOutput = 0;

            for(int i = i_binaryInput.Length - 1; i >= 0; i--)
            {
                if(i_binaryInput[i] == '1')
                {
                    decimalOutput += (int)Math.Pow(2, i_binaryInput.Length - i - 1);   // we know that i is at most 7 and 2^7 = 128 in this case so casting double to int here is OK
                }
            }

            return decimalOutput;
        }

        private static IDictionary<string, float> getAverageBits(string[] i_binaryInputs)
        {
            int numOfOnes = 0;
            int numOfZeros = 0;
            int numOfBits = 0;
            float averageNumOfOnes, averageNumOfZeros;
            float numOfInputs = i_binaryInputs.Length;  // for use of float division to get float output when calculating average
            IDictionary<string, float> averageBits = new Dictionary<string, float>();

            foreach (string binaryInput in i_binaryInputs)
            {
                foreach (char bit in binaryInput)
                {
                    if (bit == '1')
                    {
                        numOfOnes++;
                        numOfBits++;
                    }
                    if (bit == '0')
                    {
                        numOfZeros++;
                        numOfBits++;
                    }
                }
            }
            averageNumOfOnes = numOfOnes / numOfInputs;
            averageNumOfZeros = numOfZeros / numOfInputs;
            averageBits.Add("averageNumOfOnes", averageNumOfOnes);
            averageBits.Add("averageNumOfZeros", averageNumOfZeros);

            return averageBits;
        }

        private static string PowersOfTwo(int[] i_decimalInputs)
        {
            int arePowersOfTwo = 0;

            foreach (int decimalInput in i_decimalInputs)
            {
                if (decimalInput != 0 && (decimalInput & (decimalInput - 1)) == 0)  // First: make sure input isn't zero. Second: example of method: 00..1000 = 8, 8-1 = 7 = 00..111 -> & then and you get 0
                {
                    arePowersOfTwo++;
                }
            }

            return arePowersOfTwo.ToString();
        }

        private static string MonotoneIncreasing(int[] i_decimalInputs)
        {
            int areMonotoneIncreasing = 0;
            string decimalInputToString;

            foreach (int decimalInput in i_decimalInputs)
            {
                if (decimalInput < 10)  // a single digit is considered monotonically increasing
                {
                    areMonotoneIncreasing++;
                    continue;
                }
                decimalInputToString = decimalInput.ToString();
                for (int i = 1; i < decimalInputToString.Length; i++)
                {
                    if (decimalInputToString[i] < decimalInputToString[i-1])
                    {
                        break;
                    }
                    if (i == decimalInputToString.Length - 1) // we made it to the end of the list while checking that every digit is greater than its predecessor
                    {
                        areMonotoneIncreasing++;
                    }
                }
            }

            return areMonotoneIncreasing.ToString();
        }
    }
}

