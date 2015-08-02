using System;
using System.Management;
namespace CMDSpecs
{
    class Program
    {

        public static int bytesToGig = 1000000000;
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");


                //  Print CPU Data

                Console.WriteLine(" \n >>>>CPU<<<< \n");
                foreach (ManagementObject moProcessor in mosProcessor.Get())
                {


                    // Manufacturer
                    if (moProcessor["manufacturer"] != null)
                        Console.WriteLine("Manufacturer: " + moProcessor["manufacturer"].ToString());
                    //Name
                    if (moProcessor["name"] != null)
                        Console.WriteLine("Name: " + moProcessor["name"].ToString());

                    //Data Width
                    if (moProcessor["datawidth"] != null)
                        Console.WriteLine("Data Width: " + moProcessor["datawidth"].ToString() + "bit");

                    //Clock Speed
                    if (moProcessor["maxclockspeed"] != null)
                        Console.WriteLine("Clock Speed: " + moProcessor["maxclockspeed"].ToString() + " Mhz");




                }

                Console.WriteLine(" \n >>>>RAM<<<< \n");
                Console.WriteLine("Capacity: " + (long)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / bytesToGig + "GB");

            }



        }
    }
}
