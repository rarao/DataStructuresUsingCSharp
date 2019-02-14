using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUsingCSharp.Stacks
{
    public static class ProblemsOnStacks
    {
        private static int Precedence(char c)
        {
            char[] op = new char[] { '%', '*', '/', '+', '-' };

            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] == c)
                    return (op.Length - i);
            }

            Console.WriteLine("Invalid character to get precedence , returning -1");
            return -1;
        }
        private static bool IsOperand(char c)
        {
            int ascii = (int)c;
            if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
                return true;
            return false;
        }

        private static bool IsOperator(char c)
        {
            char[] op = new char[] { '%', '*', '/', '+', '-' };

            if (op.Contains(c))
                return true;
            return false;
        }

        //Infix to Postfix conversion using stack
        public static string InfixToPostfix(string input)
        {
            StringBuilder output = new StringBuilder(String.Empty);
            Stack<char> myStack = new Stack<char>();

            foreach (char c in input)
            {
                if (IsOperand(c))
                    output.Append(c);
                else if (c.Equals(')'))
                {
                    char temp = myStack.Pop();
                    while (temp != '(')
                    {
                        if(myStack.Count == 0)
                        {
                            Console.WriteLine("Invalid input.");
                            return null;
                        }
                        output.Append(temp);
                        temp = myStack.Pop();
                    }
                }
                else if (c.Equals('('))
                {
                    myStack.Push(c);
                }
                else if (IsOperator(c))
                {
                    if (myStack.Count != 0 && !myStack.Peek().Equals('(') && Precedence(myStack.Peek()) >= Precedence(c))
                    {
                        output.Append(myStack.Pop());
                    }
                    myStack.Push(c);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    return null;
                }
            }

            while(myStack.Count != 0)
            {
                output.Append(myStack.Pop());
            }

            return output.ToString();
        }
    }
}
