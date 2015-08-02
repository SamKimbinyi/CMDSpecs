using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CMDSpecs
{
    public class Hardware
    {

        public static int bytesToGig = 1000000000;
        public static ManagementObjectSearcher Searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");


        //  Print CPU Data
        public static void showCPU()
        {

            Console.WriteLine(" \n >>>>CPU<<<< \n");
            foreach (ManagementObject processor in Searcher.Get())
            {


                // Manufacturer
                if (processor["manufacturer"] != null)
                    Console.WriteLine("Manufacturer: " + processor["manufacturer"].ToString());
                //Name
                if (processor["name"] != null)
                    Console.WriteLine("Name: " + processor["name"].ToString());

                //Data Width
                if (processor["datawidth"] != null)
                    Console.WriteLine("Architecture: " + processor["datawidth"].ToString() + "bit");

                //Clock Speed
                if (processor["maxclockspeed"] != null)
                    Console.WriteLine("Clock Speed: " + processor["maxclockspeed"].ToString() + " Mhz");

                //Physical Cores
                if (processor["numberofcores"] != null)
                    Console.WriteLine("Physical Cores: " + processor["numberofcores"].ToString());

                Console.WriteLine("Core Count: " + Environment.ProcessorCount);




            }

        }
        
        //Get RAM
        public static void showRam()
        {
            
            Console.WriteLine(" \n >>>>RAM<<<< \n");
            Console.WriteLine("Capacity: " + (long)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / bytesToGig + "GB");
        }




        //Get GPU 
        public static void showGPU()
        {

            Console.WriteLine(" \n >>>>GPU<<<< \n");

            foreach (ManagementObject mo in Searcher.Get())
            {
                foreach (PropertyData gpu in mo.Properties)
                {
                    if (gpu.Name == "Description")
                    {
                        Console.WriteLine("Graphics Processing Unit: " + gpu.Value.ToString());
                    }
                }


            }
        }

        //Show All Specs
        public static void showAll()
        {
            showCPU();
            showGPU();
            showRam();

        }
    }
}
