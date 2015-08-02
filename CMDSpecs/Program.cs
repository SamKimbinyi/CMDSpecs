using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace CMDSpecs
{
    class Program
    {

       
        public static String command;
        static void Main(string[] args)
        {

            try
            {
                command = (string)args[0];
            }
            catch (System.IndexOutOfRangeException e) {
                command = "";
            }
          

            switch (command.ToLower()) {

                case "cpu":
                    Hardware.showCPU();
                    break;

                case "gpu":
                    Hardware.showGPU();
                    break;

                case "ram":
                    Hardware.showRam();
                    break;


                default:
                    Hardware.showAll();
                    break;
            }

#if DEBUG
            Console.ReadLine(); //Stops Closing Automatically
#endif











        }



    }
    }

