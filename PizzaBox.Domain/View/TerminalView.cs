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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"

















    ____    __    ____  _______  __        ______   ______   .___  ___.  _______    .___________. ______      .______    __   ________   ________      ___         .______     ______   ___   ___ 
    \   \  /  \  /   / |   ____||  |      /      | /  __  \  |   \/   | |   ____|   |           |/  __  \     |   _  \  |  | |       /  |       /     /   \        |   _  \   /  __  \  \  \ /  / 
     \   \/    \/   /  |  |__   |  |     |  ,----'|  |  |  | |  \  /  | |  |__      `---|  |----|  |  |  |    |  |_)  | |  | `---/  /   `---/  /     /  ^  \       |  |_)  | |  |  |  |  \  V  /  
      \            /   |   __|  |  |     |  |     |  |  |  | |  |\/|  | |   __|         |  |    |  |  |  |    |   ___/  |  |    /  /       /  /     /  /_\  \      |   _  <  |  |  |  |   >   <   
       \    /\    /    |  |____ |  `----.|  `----.|  `--'  | |  |  |  | |  |____        |  |    |  `--'  |    |  |      |  |   /  /----.  /  /----./  _____  \     |  |_)  | |  `--'  |  /  .  \  
        \__/  \__/     |_______||_______| \______| \______/  |__|  |__| |_______|       |__|     \______/     | _|      |__|  /________| /________/__/     \__\    |______/   \______/  /__/ \__\ 
                                                                                                                                                                                              
                                                                                                                                                                                                                                                       

                                                                                          Press Any Key to Continue                                    ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(@"



===========================================================================================================================================================================================
=                                       PizzaBox is a Demostration Software for a simple set of commands to connect and retrieve                                                          =
=                                       from a database utilizing the C# progamming language along. In todays demonstation we will                                                        =
=                                       be showing very rudimentary procedures of a point of sale system or POS for short.                                                                =
=                                                                                                                                                                                         =
=                                                                                                                                                                                         =
=                                                                                                                                                                                         =
=                                                                                                                                                                                         =
=                                                                                                                                                                                         =
=                                                                                                                                                                                         =
=                                                                                                                                                                                         =
============================================================================================================================================================================================
                                                                                                                                                                                                                                                       

                                                                                          Press Any Key to Continue                                    ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}