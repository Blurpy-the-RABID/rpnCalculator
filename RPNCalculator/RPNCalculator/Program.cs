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
            string[] tokens = userInput.Split(' ');
            Stack tokenStack = new Stack(); // This Stack shall contain the user's input.

            foreach (string token in tokens) {
                if (token == "+" || token == "-" || token == "*" || token == "/") {
                    tokenStack.Pop();
                }
                else {
                    tokenStack.Push(token);
                }
            }
            Console.WriteLine("Answer: {0}", tokenStack);


            // Now that we've assigned the user's input to a Stack, we'll now scroll through the user's input and perform calculations whenever an operator is encountered.
        }
    }
}