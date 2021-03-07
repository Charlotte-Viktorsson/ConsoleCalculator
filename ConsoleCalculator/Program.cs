using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Program
    {
        /// <summary>
        /// Main method presents a simple Console Calculator meny and take action from user input.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            var keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("--- Menu ---\nChoose method \n+ :  Addition\n- :  Subtraction\n* :  Multipication \n/ :  Division\n" +
                    "a :  Addition of several nrs\ns :  Subtraction of several nrs\nq :  Quit");

                char userKeyPress = Console.ReadKey(true).KeyChar;

                switch (userKeyPress)
                {
                    case '+':
                        Console.WriteLine("Addition");
                        double addTerm1 = AskForNr("term 1 to add");
                        if (addTerm1 != -1)
                        {
                            double addTerm2 = AskForNr("term 2 to add");
                            if (addTerm2 != -1)
                            {
                                Console.Write(addTerm1 + " + " + addTerm2 + " = " + Addition(addTerm1, addTerm2));
                            }
                        }
                        Console.WriteLine();
                        break;
                    case '-':
                        Console.WriteLine("Subtraction");
                        double subtractTerm1 = AskForNr("term 1 to subtract from");
                        if (subtractTerm1 != -1)
                        {
                            double subtractTerm2 = AskForNr("term 2 to subtract");
                            if (subtractTerm2 != -1)
                            {
                                Console.Write(subtractTerm1 + " - " + subtractTerm2 + " = " + Subtraction(subtractTerm1, subtractTerm2));
                            }
                        }
                        Console.WriteLine();
                        break;
                    case '/':
                        Console.WriteLine("Division");
                        double numerator = AskForNr("numerator");
                        if (numerator != -1)
                        {
                            double denominator = AskForNr("denominator");
                            if (denominator == 0)
                            {
                                Console.WriteLine("Denominator must not be 0!");
                            }
                            else if (denominator != -1)
                            {
                                Console.Write(numerator + " / " + denominator + " = " +  Division(numerator, denominator));
                            }
                        }
                        Console.WriteLine();
                        break;
                    case '*':
                        Console.WriteLine("Multiplication");
                        double term1 = AskForNr("term 1 to multiply");
                        if (term1 != -1)
                        {
                            double term2 = AskForNr("term 2 to multiply with");
                            if (term2 != -1)
                            {
                                Console.Write(term1 + " * " + term2 + " = " + Multiply(term1,term2));
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 'a':
                        Console.WriteLine("Addition of several numbers");
                        List<double> doubleAddList = takeNumbers("add");
                        string additionAnswer = Addition(doubleAddList.ToArray());
                        Console.WriteLine(additionAnswer);
                        break;
                    case 's':
                        Console.WriteLine("Subtraction with several numbers");
                        List<double> doubleSubList = takeNumbers("subtract");
                        String subtractionAnswer = Subtraction(doubleSubList.ToArray());
                        Console.WriteLine(subtractionAnswer);

                        break;
                    case 'q':
                        keepRunning = false;
                        Console.WriteLine("Thanks for using the Calculator!");
                        break;
                    default:
                        Console.WriteLine("Invalid keypress");
                        break;
                }   
            }    
        }

        /// <summary>
        /// Method ask user for numbers and returns them in a List.
        /// If Exceptions are caught from the user input, messages will be shown.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>List of doubles</returns>
        private static List<double> takeNumbers(string userInfo)
        {
            List<double> doubleList = new List<double>();
            char addMoreNrs = 'y';

            while (addMoreNrs == 'y')
            {
                if (userInfo == "subtract" && doubleList.Count == 0)
                {
                    Console.WriteLine("Enter startnr to subtract from: ");
                }
                else 
                {
                    Console.WriteLine("Enter a nr to " + userInfo + ": ");
                }
                
                try
                {
                    double d = Convert.ToDouble(Console.ReadLine());
                    doubleList.Add(d);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format of nr, use only 0-9 and , for fractions");

                }
                catch (OverflowException)
                {
                    Console.WriteLine("This term is too big to calculate.");
                }
                Console.WriteLine("Enter more numbers y/n : ");
                addMoreNrs = Console.ReadKey(true).KeyChar;

            }
            return doubleList;
        }

        /// <summary>
        /// Method asks user for a nr and returns it.
        /// If Exceptions are caught, a message will be shown and -1 is returned
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>double</returns>
        static double AskForNr(string userInfo)
        {
            Console.Write($"Please type in {userInfo}: ");
            double nr = 0;
            try
            {
                //nr = Convert.ToInt32(Console.ReadLine());
                nr = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid nr, only use keys 0 to 9 and , for fractions");
                nr = -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Nr is too big or small to work with, try again!");
                nr = -1;
            }
            return nr;
        }

        /// <summary>
        ///     The method multiplies two double values and returns the product
        /// </summary>
        /// <param name="term1">double term1</param>
        /// <param name="term2">double term2</param>
        /// <returns>double Product</returns>
        public static double Multiply(double term1, double term2)
        {
            return term1 * term2;
        }

        /// <summary>
        ///     The method performs a division of two doubles inparameters and returns the quota.
        ///     If the denominator is 0, a console message will complain and 0 is returned.
        /// </summary>
        /// <param name="numerator">double numerator</param>
        /// <param name="denominator">double denominator</param>
        /// <returns>The quota</returns>
        public static double Division(double numerator, double denominator)
        {
            if (denominator != 0)
            {
                return numerator / denominator;
            }
            else
            {
                Console.WriteLine("The Denominator must not be 0!");
                return 0;
            }
        }

        /// <summary>
        ///  Method adds two double inparameters and returns the sum of them.
        /// </summary>
        /// <param name="term1"></param>
        /// <param name="term2"></param>
        /// <returns>Sum of the 2 inparameters</returns>
        public static double Addition(double term1, double term2)
        {
            return term1 + term2;
        }

        /// <summary>
        ///     Method will try to add doubles from an array and return a string
        /// </summary>
        /// <param name="doubleArray"></param>
        /// <returns>String with the Sum</returns>
        public static string Addition(double[] doubleArray)
        {
            string answer = "";
            double sum = 0;
            
            if (doubleArray == null || doubleArray.Length == 0)
            {
                answer = "No number entered.";
                
            }
            else
            {
                answer += "Adding ";
                foreach (double nr in doubleArray)
                {
                    answer += nr + " ";
                    sum += nr;
                }
                answer += "\nSum is " + sum;    
            }
            answer += "\n";
            
            return answer;
        }

        /// <summary>
        /// Method subtracts term2 from term1 and returns the difference
        /// </summary>
        /// <param name="term1"></param>
        /// <param name="term2"></param>
        /// <returns>The Difference</returns>
        public static double Subtraction(double term1, double term2)
        {
            return term1 - term2;
        }

        /// <summary>
        /// Method takes an array of nrs and performs subtraction from 
        /// the first nr and returns a string with the result
        /// </summary>
        /// <param name="doubleArray"></param>
        /// <returns>string with the Difference</returns>
        public static string Subtraction(double[] doubleArray)
        {
            string answer = "";
            double difference = 0;
            
            if (doubleArray == null || doubleArray.Length == 0)
            {
                answer = "No number entered";
            }
            else if (doubleArray.Length == 1)
            {
                answer = "Only one number entered: " + doubleArray[0];
            }
            else
            {
                answer = doubleArray[0] + " ";
                difference = doubleArray[0];
                for (int i = 1; i < doubleArray.Length; i++)
                {
                    answer += " - " + doubleArray[i];
                    difference -= doubleArray[i];
                }
                answer += "\nDifference is " + difference;
 
            }
            answer += "\n";
            return answer;
        }
    }//end of class program
}//end of namespace