using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class Reservation : EntityBase
    {
        public int Id { get; set; }

        //public string Name { get; set; }
        public virtual Room Room { get; set; }

        public DateTime StarTime { get; set; }
        public decimal PeriodByHours { get; set; }
    }
}