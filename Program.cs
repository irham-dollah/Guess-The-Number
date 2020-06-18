using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace GuessTheNumber
{
    class Program
    {

        
        //static = we refer to function itself. it is not instances
        static void Main(string[] args)
        {
            //set app vars
            string appName = "Guess The Number";
            string appVersion = "1.0.0";
            string appAuthor = "Irham Dollah";
            string ansStr;
            int ansNum=0;
            string cont="YES";
            //int answer = 0;

            while (cont.ToUpper() == "YES")
            {
                Console.Clear();
                Begin();
                //create randomNum
                int correctNum = RandomNum();
                //let user guess
                
                Console.Write("Guess the number: ");
                while (ansNum != correctNum)
                {
                    ansStr = Console.ReadLine();
                    //check number or alphabet
                    if (!int.TryParse(ansStr, out ansNum))
                    {
                        colorMessage(bg:ConsoleColor.Blue, m:"Put number only: ");
                        continue;
                    }
                    //if answer is wrong
                    if (ansNum != correctNum)
                    {
                        //change color for wrong
                        colorMessage(fg: ConsoleColor.Red, m: "\nWrong !");
                        Hint(correctNum);
                        colorMessage(ConsoleColor.Black,ConsoleColor.Red,"\nTry again...");
                        //Ask to try again
                        Console.Write("\nGuess the number: ");
                    }
                }
                //change color for correct
                colorMessage(fg:ConsoleColor.Yellow, m: "\nCorrect !");
                //separation
                Console.WriteLine("\n-----------------------");
                //ask for new game
                Console.Write("\nNew Game? (YES/NO): ");
                cont=Console.ReadLine();
            }

            void Begin()
            {
                //change color
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;

                //app info
                Console.WriteLine("{0} : V {1} \nCreated By {2}", appName, appVersion, appAuthor);

                //Reset color
                Console.ResetColor();

                //Get user name
                Console.Write("\nInput your name: ");
                string name = Console.ReadLine();
                Console.WriteLine("\nHi {0}, let's play a game", name.ToUpper());

            }

            int RandomNum()
            {
                //Create correct random number
                Random num = new Random();
                int newNum = num.Next(10, 21);
                return newNum;
            }

            int hintRanNum()
            {
                //Create random number for hint
                Random num = new Random();
                int newNum = num.Next(1, 8);
                return newNum;
            }

            void colorMessage(ConsoleColor fg=ConsoleColor.White,
                ConsoleColor bg=ConsoleColor.Black, string m="Error")
            {
                Console.ForegroundColor = fg;
                Console.BackgroundColor = bg;
                Console.Write(m);
                Console.ResetColor();
            }

            void Hint (int num)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nHint: Smaller than {0}, bigger than {1}", num + hintRanNum(), num - hintRanNum());
            }

            /*---------------------------------------*/
            Console.WriteLine("\n");
            Console.WriteLine("Thank you for joining us !");
            Console.ReadKey();
        }
    }
}
