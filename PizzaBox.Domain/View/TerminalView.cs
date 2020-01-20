using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.View
{
 public  class TerminalView
    {
        public void Terminal_Welcome()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorSize = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"












    __        __     _                                _           ____   _                  ____              
    \ \      / /___ | |  ___  ___   _ __ ___    ___  | |_  ___   |  _ \ (_) ____ ____ __ _ | __ )   ___ __  __
     \ \ /\ / // _ \| | / __|/ _ \ | '_ ` _ \  / _ \ | __|/ _ \  | |_) || ||_  /|_  // _` ||  _ \  / _ \\ \/ /
      \ V  V /|  __/| || (__| (_) || | | | | ||  __/ | |_| (_) | |  __/ | | / /  / /| (_| || |_) || (_) |>  < 
       \_/\_/  \___||_| \___|\___/ |_| |_| |_| \___|  \__|\___/  |_|    |_|/___|/___|\__,_||____/  \___//_/\_\
                                                                                                           
                            

                                        Press Any Key to Continue





    
                                                                                                                                                                                              
                                                                                                                                                                                                                                                       

                                                                                                                              ");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(2, Console.LargestWindowHeight/3);

            Console.WriteLine(@"
     ========================================================================================================================================
     =              PizzaBox is a Demostration Software for a simple set of commands to connect and retrieve                                =
     =              from a database utilizing the C# progamming language along. In todays demonstation we will                              =
     =              be showing very rudimentary procedures of a point of sale system or POS for short.                                      =
     =                                                                                                                                      =
     =                                                                                                                                      =
     =                                                                                                                                      =
     =                                                                                                                                      =
     =                                                                                                                                      =
     =                                                                                                                                      =
     =                                                                                                                                      =
     ========================================================================================================================================
                                                                                                                                                                                                                                                       

                                              Press Any Key to Continue                                    ");
            Console.ReadKey();
            Console.Clear();
        }

    }
}