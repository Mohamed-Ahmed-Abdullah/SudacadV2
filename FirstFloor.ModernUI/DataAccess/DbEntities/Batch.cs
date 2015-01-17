using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// this comes from the cources price, for indevidual and for organizations
        /// </summary>
        //public decimal Price { get; set; }

        public decimal TeacherCost { get; set; }
        public decimal OtherCosts { get; set; }

        public decimal HospitalityIndividual { get; set; }
        public decimal HospitalityOrgnization { get; set; }

        //this should be read only and set when the status become started
        public DateTime StartDate { get; set; }

        //TODO: depends on [cources periods, reservations] this should be calculated form all the cources periods and reservations
        //[NotMapped]
        //public DateTime EndDate { get; set; }

        //TODO: depends on [cources lab and lecture periods] this should be calculated from the cources periods
        //public int Period { get; set; }

        //MinTraineeCount to make the batch able to start, and the teacher satisfied 
        public int MinTraineeCount { get; set; }
        //MaxTraineeCount to make the teacher satisfied, teacher usually said "i will not start this cource unless the there is at least 10 people and max 30 people or it's a new cource"
        public int MaxTraineeCount { get; set; }
         
        //public virtual List<Course> Courses { get; set; }
        public virtual List<Course> Course { get; set; }

        //TODO: should be changed to schedules, but for now
        //public virtual List<Reservation> Reservations { get; set; }

        public virtual List<Teacher> Teachers { get; set; }

        public virtual List<BatchOrganization> Organizations { get; set; }
        public virtual List<BatchTrainee> Trainees { get; set; }
    }
}