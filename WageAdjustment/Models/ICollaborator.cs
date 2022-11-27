using System;

namespace WageAdjustment.Models
{
    public interface ICollaborator
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public double CurrentSalary { get; set; }
        public int HiringYear { get; set; }
    }
}
