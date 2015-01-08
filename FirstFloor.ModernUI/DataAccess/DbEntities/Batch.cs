using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class Batch : EntityBase
    {
        public int BatchId { get; set; }

        public string ArabicName { get; set; }
        public string EnglishName { get; set; }

        /// <summary>
        /// this is the default price unless there is discount
        /// </summary>
        public decimal Price { get; set; }

        public decimal TeacherCost { get; set; }
        public decimal OtherCosts { get; set; }

        public decimal HospitalityIndividual { get; set; }
        public decimal HospitalityOrgnization { get; set; }

        public DateTime StartDate { get; set; }

        //TODO: this should be calculated form the period, and from the all cources periods 
        public DateTime EndDate { get; set; }

        //TODO: this should be calculated from the cources periods
        //this is from the cources period, no need for it here
        public int Period { get; set; }

        //TODO: no need for this two fields Maxtraineecount MinTraineecount
        //i don't know if that is usefull, you can see if your rooms could fit
        public int MinTraineeCount { get; set; }
        public int MaxTraineeCount { get; set; }

        //TODO: this should be cources but for now make it course
        //public virtual List<Course> Courses { get; set; }
        public virtual Course Course { get; set; }

        //TODO: should be changed to schedules, but for now
        //public virtual List<Reservation> Reservations { get; set; }

        public virtual Room Room { get; set; }

        public virtual List<Organization> Organizations { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Trainee> Trainees { get; set; }
    }
}