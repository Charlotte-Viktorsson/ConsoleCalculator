using System;


namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            var keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("--- Menu ---\nChoose method \n+ :  Addition \n- :  Subtraction \n* :  Multipication \n/ :  Division\n\nq :  Quit");

                char userKeyPress = Console.ReadKey(true).KeyChar;

                switch (userKeyPress)
                {
                    case '+':
                        Addition();
                        break;
                    case '-':
                        Subtraction();
                        break;
                    case '/':
                        Division();
                        break;
                    case '*':
                        Multiply();
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
        private static void Multiply()
        {
            Console.WriteLine("Multiplication");
            double term1 = AskForNr("term 1 to multiply");
            if (term1 != -1)
            {
                double term2 = AskForNr("term 2 to multiply with");
                if( term2 != -1)
                {
                    Console.Write(term1 + " * " + term2 + " = " + (term1 * term2));
                }  
            }
            Console.WriteLine();
        }

        private static void Division()
        {
            Console.WriteLine("Division");
            double numerator = AskForNr("numerator");
            if (numerator != -1)
            {
                double denominator = AskForNr("denominator");
                if (denominator == 0)
                {
                    Console.WriteLine("Denominator must not be 0!");
                }
                else if(denominator != -1)
                {
                    Console.Write(numerator + " / " + denominator + " = " + (numerator / denominator));
                }
            }
            Console.WriteLine();
        }

        private static void Subtraction()
        {
            Console.WriteLine("Subtraction");
            double term1 = AskForNr("term 1 to subtract from");
            if (term1 != -1)
            {
                double term2 = AskForNr("term 2 to subtract");
                if (term2 != -1)
                {
                    Console.Write(term1 + " - " + term2 + " = " + (term1 - term2));
                }
            }
            Console.WriteLine();
        }

        private static void Addition()
        {
            Console.WriteLine("Addition");
            double term1 = AskForNr("term 1 to add");
            if (term1 != -1)
            {
                double term2 = AskForNr("term 2 to add");
                if (term2 != -1)
                {
                    Console.Write(term1 + " + " + term2 + " = " + (term1 + term2));
                }
            }
            Console.WriteLine();
        }
    }//end of class program
}//end of namespace