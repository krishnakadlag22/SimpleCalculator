/*using System;

namespace SimpleCalculatorApp
{
    class Program
    {
        /// <summary>
        /// Entry point: Parses and evaluates a simple arithmetic expression passed via command-line.
        /// </summary>
        /// <param name="args">Expression string (e.g., "10*2-8")</param>
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: SimpleCalculator <expression>");
                return;
            }

            string expression = args[0];
            string numbersTemp = "";
            int[] numbers = new int[100];
            char[] operators = new char[100];
            int numCount = 0, opCount = 0;

            // Validate and separate numbers/operators
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c))
                {
                    numbersTemp += c;
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (numbersTemp == "")
                    {
                        Console.WriteLine("Error: Invalid format (operator without left number).");
                        return;
                    }

                    numbers[numCount++] = int.Parse(numbersTemp);
                    operators[opCount++] = c;
                    numbersTemp = "";
                }
                else
                {
                    Console.WriteLine("Error: Invalid character found.");
                    return;
                }
            }

            if (numbersTemp == "")
            {
                Console.WriteLine("Error: Expression ends with an operator.");
                return;
            }
            numbers[numCount++] = int.Parse(numbersTemp);

            // First pass: handle * and /
            int[] firstPassNumbers = new int[100];
            char[] firstPassOperators = new char[100];
            int idx = 0;
            firstPassNumbers[idx++] = numbers[0];

            for (int i = 0; i < opCount; i++)
            {
                if (operators[i] == '*')
                {
                    firstPassNumbers[idx - 1] *= numbers[i + 1];
                }
                else if (operators[i] == '/')
                {
                    if (numbers[i + 1] == 0)
                    {
                        Console.WriteLine("Error: Division by zero.");
                        return;
                    }
                    firstPassNumbers[idx - 1] /= numbers[i + 1];
                }
                else
                {
                    firstPassOperators[idx - 1] = operators[i];
                    firstPassNumbers[idx++] = numbers[i + 1];
                }
            }

            // Second pass: handle + and -
            int result = firstPassNumbers[0];
            for (int i = 0; i < idx - 1; i++)
            {
                if (firstPassOperators[i] == '+')
                    result += firstPassNumbers[i + 1];
                else if (firstPassOperators[i] == '-')
                    result -= firstPassNumbers[i + 1];
            }

            Console.WriteLine("Result: " + result);
        }
    }
}
*/