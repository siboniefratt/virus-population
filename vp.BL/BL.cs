using System;
using vp.SHARED.Models;
using System.Linq;

namespace vp.BL
{
    public class BL
    {
        public const int CLEAN_PROBABILITY = 3;
        public int MULTIPLY_PROBABILITY = 10;
        public bool TryToClean(Patient patient, Virus virus)
        {
            Random rnd = new Random();
            int percent = rnd.Next(0, 10);
           
            if (percent < CLEAN_PROBABILITY)
            {
                patient.Healthy.Add(new Cell());
                patient.Sick.Remove(virus);
                Console.WriteLine("virus cleaned");
                return true;
            }
            Console.WriteLine("virus can't cleaned");
            return false;
        }
       
        public decimal CalculatMultiply(int divided, int divider) {
            decimal calc = (((divided / divider) - 1) * MULTIPLY_PROBABILITY);
            return calc;
        }
        public bool TryToMultiple(Patient patient) {
            
            Random rnd = new Random();
            int percent = rnd.Next(0, 100);
            decimal ChanceToMultiply = CalculatMultiply(patient.Healthy.Count + patient.Sick.Count, patient.Sick.Count);
          if (percent > ChanceToMultiply)
            {
                int RandomNumber = new Random().Next(0, 100);
                var newViruses = Enumerable.Repeat(new Virus(), RandomNumber).ToList();
                if(patient.Healthy.Count > newViruses.Count) 
                {
                    patient.Healthy.RemoveRange(0, newViruses.Count);
                    patient.Sick.AddRange(newViruses);
                    
                    Console.WriteLine("virus multipled : " + RandomNumber);
                }
                 
                return true;
            }
            Console.WriteLine("virus can't multipled");
            return false;
                }
        public bool StartSimulation(int infectedCells, int totalCells)
        {
            int numOfMultipled = 0;
            var patient = new Patient(infectedCells, totalCells);
            foreach (var infected in patient.Sick.ToList())
            {
                var cleaned = TryToClean(patient, infected);
                if (!cleaned)
                {
                    if (TryToMultiple(patient))
                        numOfMultipled++;
                   
                }
               
            }
            Console.WriteLine("num Of Multipled : {0} num of viruses : {1}", numOfMultipled, patient.Sick.Count);
            return false;
        }

    }
}
