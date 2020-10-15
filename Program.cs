using System;
using vp.BL;

namespace virus_population
{
    class Program
    {
        public static BL bL = new BL();
         static void Main(string[] args)
           {
             bL.StartSimulation(100, 1000);


        }
    }
}
