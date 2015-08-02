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
                ManagementObjectSearcher Processor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");


                //  Print CPU Data

                Console.WriteLine(" \n >>>>CPU<<<< \n");
                foreach (ManagementObject processor in Processor.Get())
                {


                    // Manufacturer
                    if (processor["manufacturer"] != null)
                        Console.WriteLine("Manufacturer: " + processor["manufacturer"].ToString());
                    //Name
                    if (processor["name"] != null)
                        Console.WriteLine("Name: " + processor["name"].ToString());

                    //Data Width
                    if (processor["datawidth"] != null)
                        Console.WriteLine("Data Width: " + processor["datawidth"].ToString() + "bit");

                    //Clock Speed
                    if (processor["maxclockspeed"] != null)
                        Console.WriteLine("Clock Speed: " + processor["maxclockspeed"].ToString() + " Mhz");




                }

                Console.WriteLine(" \n >>>>RAM<<<< \n");
                Console.WriteLine("Capacity: " + (long)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / bytesToGig + "GB");

            }



        }
    }
}
