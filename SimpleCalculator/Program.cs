using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    /// <summary>
    /// Simple arithmetic expression calculator supporting +, -, *, and / operators.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: SimpleCalculator <expression>");
                return;
            }

            string expression = args[0];

            if (!IsValid(expression))
            {
                Console.WriteLine("Error: Invalid characters in expression.");
                return;
            }

            int result = Evaluate(expression);
            Console.WriteLine("Result: " + result);
        }
        /// <summary>
        /// Validates that the input expression contains only digits and allowed operators.
        /// </summary>
        /// <param name="input">The input expression.</param>
        /// <returns>True if valid, false otherwise.</returns>
        // Function to validate the expression (only digits and operators allowed)
        static bool IsValid(string input)
        {
            foreach (char ch in input)
            {
                if (!char.IsDigit(ch) && !"+-*/".Contains(ch))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Evaluates a mathematical expression with operator precedence (*/ before +-).
        /// </summary>
        /// <param name="input">The expression string to evaluate.</param>
        /// <returns>The result as an integer.</returns>
        static int Evaluate(string input)
        {
            List<string> operands = new List<string>();
            List<char> operators = new List<char>();
            string current = "";

            // Parse the input expression
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if ("+-*/".Contains(ch))
                {
                    operands.Add(current);
                    operators.Add(ch);
                    current = "";
                }
                else
                {
                    current += ch;
                }
            }
            operands.Add(current); // Add the last operand

            // Handle multiplication and division first
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '*' || operators[i] == '/')
                {
                    int a = int.Parse(operands[i]);
                    int b = int.Parse(operands[i + 1]);

                    if (operators[i] == '/' && b == 0)
                    {
                        Console.WriteLine("Error: Division by zero.");
                        return 0;
                    }

                    int res = (operators[i] == '*') ? a * b : a / b;
                    /*int res
                    if (operators[i] == '*')
                    {
                        res = a * b;
                    }
                    else
                    {
                        res = a / b;
                    }*/

                    operands[i] = res.ToString();

                    // Shift the operands and operators to previous left
                    operands.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--; // Adjust the index after removal
                }
            }

            // After the all preference we move towards addition and its evaluation
            int result = int.Parse(operands[0]);

            for (int i = 0; i < operators.Count; i++)
            {
                int b = int.Parse(operands[i + 1]);
                if (operators[i] == '+')
                    result += b;
                else
                    result -= b;
            }

            return result;
        }
    }
}
