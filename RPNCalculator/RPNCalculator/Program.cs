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
            Console.WriteLine("For example, to calculate '3 + 4', you would type, '34+'.  To calculate '3 + 5 * 7', you would type, '357*+'.");
            Console.Write("Please type in the mathematical operation that you wish to calculate: ");
            string userInput = Console.ReadLine();

            Stack tokens = new Stack(); // This Stack shall contain the user's input.

            for (int i = 0; i < userInput.Length; i++) {
                tokens.Push(userInput[i].ToString());
            }

            // Now that we've assigned the user's input to a Stack, we'll now scroll through the user's input and perform calculations whenever an operator is encountered.
            int x = 0, y = 0;
            char op = '0';
            int answer = 0;

            while (tokens.Count > 0) {
                op = (char)tokens.Pop();
                y = (int)tokens.Pop() - '0';
                x = (int)tokens.Pop() - '0';
            }

            switch (op) {
                case '+':
                    answer = x + y;
                    Console.WriteLine("{0} + {1} = {2}", x, y, answer);
                    break;
                case '-':
                    answer = x - y;
                    Console.WriteLine("{0} - {1} = {2}", x, y, answer);
                    break;
                case '*':
                    answer = x * y;
                    Console.WriteLine("{0} * {1} = {2}", x, y, answer);
                    break;
                case '/':
                    answer = x / y;
                    Console.WriteLine("{0} / {1} = {2}", x, y, answer);
                    break;
            }

            /*
                        for (; ; ) {
                            if (userInput == null) break;

                            char[] sp = new char[] { ' ', '\t' };
                            Stack<string> tokens = new Stack<string>(userInput.Split(sp, StringSplitOptions.RemoveEmptyEntries));
                            if (tokens.Count == 0) continue;
                            try {
                                double r = evalrpn(tokens);
                                if (tokens.Count != 0) throw new Exception();
                                Console.WriteLine(r);
                            }
                            catch (Exception e) {
                                Console.WriteLine("error");
                                break;
                            }
                        }
                    }

                    private static double evalrpn(Stack<string> tokens) {
                        string token = tokens.Pop();
                        double x, y = 0;
                        if (!Double.TryParse(token, out x)) {
                            y = evalrpn(tokens); x = evalrpn(tokens);
                        }
                        if (token == "+") {
                            x += y;
                        }
                        else if (token == "-") {
                            x -= y;
                        }
                        else if (token == "*") {
                            x *= y;
                        }
                        else if (token == "/") {
                            x /= y;
                        }
                        else throw new Exception();
                        return x;
                    }
            */
        }
    }
}