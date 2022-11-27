using System;
using System.Globalization;

namespace WageAdjustment.Models
{
    public class Collaborator : ICollaborator
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public double CurrentSalary { get; set; }
        public int HiringYear { get; set; }

        public Collaborator(string name, string occupation, double currentSalary, int heringYear) 
        { 
            Name = name;
            Occupation = occupation;
            CurrentSalary = currentSalary; // salário atual
            HiringYear = heringYear; // ano contratação
        }

        public override string ToString() 
        {
            return "Nome: " + Name + " - Função: " + Occupation + " - Ano de contratação: " + HiringYear + " - Salário atual: R$ " + CurrentSalary.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
