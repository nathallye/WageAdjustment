using System;

namespace WageAdjustment.Models
{
    public class CollaboratorOld : Collaborator
    {
        public CollaboratorOld(string name, string occupation, double currentSalary, int heringYear): base(name, occupation, currentSalary, heringYear)
        {
            
        }

        public void SalaryAdjustment(double porcent)
        {
            CurrentSalary = (CurrentSalary * (porcent / 100)) + CurrentSalary;
        }

    }
}
