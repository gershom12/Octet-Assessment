using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Octet
{
    class OctetAssessment
    {
        // Question 2

        public void GetMultiples()
        {
            int multipleOne = 3;
            int multipleTwo = 5;
            for (int i = 1; i <= 30; i++)
            {
                if ((i % multipleOne) == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if ((i % multipleTwo) == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if ((i % multipleOne) == 0 && (i % multipleTwo) == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Question 3

        public void Calculator(string [] expressions)
        {
            string operation;
            string expression;
            int index;
            string[] lines = expressions;
            for (int i = 0; i < lines.Length; i++)
            {
                expression = lines[i];

                index = expression.IndexOf(':');
                operation = expression.Substring(0, index).Trim();
                var operationOperands = expression.Split(','); //return only numbers from string
                switch (operation.Trim())
                {
                    case "SUM":
                        var sum = Sum(operationOperands);
                        Console.WriteLine("SUM " + sum);
                        break;
                    case "MIN":
                        var min = Min(operationOperands);
                        Console.WriteLine("MIN " + min);
                        break;
                    case "MAX":
                        var max = Max(operationOperands);
                        Console.WriteLine("MAX " + max);
                        break;
                    case "AVERAGE":
                        var average = Average(operationOperands);
                        Console.WriteLine("Average " + average);
                        break;
                    default:
                        Console.WriteLine("Undefined Operation");
                        break;
                }
 
            }
        }

        // Check if the expression read from the file is in a correct format

        public bool validateExpression(string expression)
        {
            String temp= "";
            bool result = false;
            int count = 0;
            for(int i = 0; i< expression.Length; i++)
            {
                if(Char.IsLetter(expression[i]))
                {
                    temp = temp + expression[i];
                }
            }
            if(temp.Equals("SUM") || temp.Equals("MIN") || temp.Equals("MAX") || temp.Equals("AVERAGE"))
            {
                result = true;
            }
            if(result)
            {
               if(expression[temp.Length] ==':')
               {
                    result = true;
                    count = expression.IndexOf(':');
                    count++;
               }
               else
               {
                   result = false;
               }
            }
            if(result)
            {
                var str = expression[count];
                if (expression[count] == ' ')
                {
                    result = true;
                    count++;
                }
                else
                {
                    result = false;
                }
            }
            if(result)
            {
                for(int i = count; i<expression.Length; i++)
                {
                    if(!Char.IsDigit(expression[i]))
                    {
                        if (!(expression[i] == ','))
                        {
                            result = false;
                        }
                    }

                }
            }
            return result;
        }

        public int Sum(string[] operandArray)
        {
            int result = 0;
            int operand = 0;
            for (int i = 0; i < operandArray.Length; i++)
            {
                int.TryParse(Regex.Match(operandArray[i], @"\d+").Value, out operand);
                result += operand;
            }
            return result;
        }

        public int Min(string[] operandArray)
        {
            int[] numericOperands = new int[operandArray.Length];
            int operand = 0;
            for (int i = 0; i < operandArray.Length; i++)
            {
                int.TryParse(Regex.Match(operandArray[i], @"\d+").Value, out operand);
                numericOperands[i] = operand;
            }
            return numericOperands.Min();
        }

        public int Max(string[] operandArray)
        {
            int[] numericOperands = new int[operandArray.Length];
            int operand = 0;
            for (int i = 0; i < operandArray.Length; i++)
            {
                int.TryParse(Regex.Match(operandArray[i], @"\d+").Value, out operand);
                numericOperands[i] = operand;
            }
            return numericOperands.Max();
        }

        public int Average(string[] operandArray)
        {
            int[] numericOperands = new int[operandArray.Length];
            int operand = 0;
            int avarage = 0;
            for (int i = 0; i < operandArray.Length; i++)
            {
                int.TryParse(Regex.Match(operandArray[i], @"\d+").Value, out operand);
                avarage += operand;
            }
            avarage = avarage / operandArray.Length;
            return avarage;
        }

        // Question 4

        public int SmallestProduct(int[] arr)
        {
            // Assumption1: If the array has one element just return that element
            if (arr.Length == 1)
                return arr[0];
            // Assumption2: If the array has two elements, return the product of those two elements
            if (arr.Length == 2)
                return arr[0] * arr[1];
            Array.Sort(arr);
            return Math.Min(arr[arr.Length - 1] * arr[arr.Length - 2] * arr[0], arr[0] * arr[1] * arr[2]);
        }

        static void Main(string[] args)
        {
            OctetAssessment prog = new OctetAssessment();
            prog.testQuestio2(prog);
            Console.WriteLine();
            Console.WriteLine();
            prog.testQuestion3(prog);
            Console.WriteLine();
            Console.WriteLine();
            prog.testQuestion4(prog);
        }

        // Tests for question 2
        public void testQuestio2(OctetAssessment prog)
        {
            Console.WriteLine("Test Caclulator");
            Console.WriteLine();
            Console.WriteLine();

            for(int i = 1; i<=30;i++)
            {
                prog.GetMultiples();
            }

        }

        // Tests for question 3
        // Reading from file feature has not been implemneted yet

        public void testQuestion3(OctetAssessment prog)
        {
            Console.WriteLine("Test Caclulator");
            Console.WriteLine();
            Console.WriteLine();

            // Test for valid expressions

            string[] expressions = new string[4];
            expressions[0] = "SUM: 1, 2, 3 ";
            expressions[1] = "MIN: 4, 3, 2, 40 ";
            expressions[2] = "MAX: 8, 2, 1, 51 ";
            expressions[3] = "AVERAGE: 2, 2 ";
            prog.Calculator(expressions);
            // Test for malformed input


        }

        // Tests for Question 4

        public void testQuestion4(OctetAssessment prog)
        {
            Console.WriteLine("Test SmallestProduct");
            Console.WriteLine();
            Console.WriteLine();
            int[] testArray1 = new int[] { 1,2, 3};
            int[] testArray2 = new int[] { -1, 0,-2, 3};
            Console.WriteLine(prog.SmallestProduct(testArray1));
            Console.WriteLine(prog.SmallestProduct(testArray2));
        }
    }
}
