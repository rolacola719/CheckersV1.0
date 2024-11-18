using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraughtsGameV2.UI
{
        public class Input
        {
        bool rulesVisible = true;
        /// <summary>
        /// accepts an input of coordinates on the board
        /// </summary>
        public void GetCoordinates(out int xCord, out int yCord)
            {
                xCord = 0;
                yCord = 0;
                while (true)
                {
                    Console.SetCursorPosition(1, 21);
                    string input = Console.ReadLine();
                if (input == "r" || input == "R")
                {
                    if (rulesVisible)
                    {
                        UIManager.CollapseRules();
                        rulesVisible = false;
                    }
                    else if (!rulesVisible)
                    {
                        UIManager.DisplayRules();
                        rulesVisible = true;
                    }
                }

                    Console.SetCursorPosition(1, 21);
                    Console.WriteLine("              ");

                    if (input.Length != 2)
                    {
                        Console.SetCursorPosition(1, 22);
                        Console.WriteLine("Please enter a valid 2-digit coordinate.");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(1, 22);
                        Console.WriteLine("                                                 ");
                        continue;
                    }

                {

                }

                    string xPosString = input.Substring(0, 1);
                    string yPosString = input.Substring(1);

                    if (int.TryParse(xPosString, out xCord) && int.TryParse(yPosString, out yCord))
                    {
                        if ((xCord >= 0 && xCord <= 7) && (yCord >= 0 && yCord <= 7))
                        {
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 22);
                            Console.WriteLine("Please write a valid coordinate");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(1, 22);
                            Console.WriteLine("                                                 ");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 22);
                        Console.WriteLine("Please write a valid coordinate");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(1, 22);
                        Console.WriteLine("                                                 ");
                    }
                }
            }
            /// <summary>
            /// accepts an input of either 1, 3, 7, or 9
            /// </summary>f
            public int MoveToPos()
            {
                int output;
                while (true)
                {
                    Console.SetCursorPosition(1, 22);
                    Console.WriteLine(@"
      7       9
       \     /
        [---]                 
       /     \
      1       3");
                    Console.SetCursorPosition(1, 21);
                    if (int.TryParse(Console.ReadLine(), out output) && (output == 1 || output == 3 || output == 7 || output == 9))
                    {

                        Console.SetCursorPosition(1, 21);
                        Console.WriteLine("              ");
                        
                        Console.SetCursorPosition(1, 22);
                        Console.WriteLine(@"
                      
                      
                           
                     
                       ");
                        Console.SetCursorPosition(1, 22);
                    return output;
                      
                    }
                    else
                        Console.SetCursorPosition(1, 22);
                    Console.WriteLine("Please enter a valid direction");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(1, 22);
                }
            }
        }
    }

