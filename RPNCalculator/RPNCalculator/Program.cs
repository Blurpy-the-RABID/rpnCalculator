using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPNCalculator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Welcome to the Reverse Polish Notation Calculator Program, written by Vincent Fantini.");
            Console.WriteLine("This calculator only uses the basic mathematical operators: +, -, *, and /.");
            Console.WriteLine("To properly use this calculator you must enter the operands first, followed by the operator.");
            Console.WriteLine("For example, to calculate '3 + 4', you would type, '3 4 +'.  To calculate '3 + 5 * 7', you would type, '3 5 7 * +'.");
            Console.Write("Please type in the mathematical operation that you wish to calculate: ");
            string userInput = Console.ReadLine();
            decimal result = calculateRPN(userInput);
            Console.WriteLine("\nResult is {0}", result);
        }

        // I changed my code to work like the code I found at Rosettacode.org (http://rosettacode.org/wiki/Parsing/RPN_calculator_algorithm#C.23).
        // I see now that I was overcomplicating how I was handling the Stack.  It's actually much simpler than I originally thought.

        static decimal calculateRPN(string rpn) {
            string[] tokens = rpn.Split(' ');
            Stack<decimal> tokenStack = new Stack<decimal>(); // This Stack shall contain the user's input.
            decimal number = decimal.Zero;

            foreach (string token in tokens) {
                if (decimal.TryParse(token, out number)) {
                    tokenStack.Push(number);
                }
                else {
                    switch (token) {
                        case "*":
                            tokenStack.Push(tokenStack.Pop() * tokenStack.Pop());
                            break;
                        case "/":
                            number = tokenStack.Pop();
                            tokenStack.Push(tokenStack.Pop() / number);
                            break;
                        case "+":
                            tokenStack.Push(tokenStack.Pop() + tokenStack.Pop());
                            break;
                        case "-":
                            number = tokenStack.Pop();
                            tokenStack.Push(tokenStack.Pop() - number);
                            break;
                        default:
                            Console.WriteLine("Error in calculateRPN method!");
                            break;
                    }
                }
                PrintState(tokenStack);
            }
            return tokenStack.Pop();
        }

        // This is a rather useful function.  It allows us to see the mathwork as it's being done.  Again, credit goes to the code I found on Rosettacode.org.
        static void PrintState(Stack<decimal> stack) {
            decimal[] arr = stack.ToArray();

            for (int i = arr.Length - 1; i >= 0; i--) {
                Console.Write("{0,-8:F3}", arr[i]);
            }

            Console.WriteLine();
        }
    }
}