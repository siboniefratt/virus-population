using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vp.SHARED.Models
{
    public class Patient
    {
        public List<Virus> Sick { get; set; } = new List<Virus>();
        public List<Cell> Healthy { get; set; } = new List<Cell>();
       
            public Patient(int infected, int total)
            {
                Sick = Enumerable.Repeat(new Virus(), infected).ToList();
                Healthy = Enumerable.Repeat(new Cell(), total - infected).ToList();
            }
        }

    }

