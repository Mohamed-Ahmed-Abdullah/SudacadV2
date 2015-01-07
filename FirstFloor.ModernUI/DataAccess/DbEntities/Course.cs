using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class Course : EntityBase
    {
        public int CourseId { get; set; }

        [StringLength(200)]
        public string ArabicName { get; set; }
        [StringLength(200)]
        public string EnglishName { get; set; }

        [Column("CourseTypeId")]
        public virtual CourseType CourseType { get; set; }

        public decimal IndividualsPrice { get; set; }
        public decimal OrganizationsPrice { get; set; }

        public TimeSpan LectureHours { get; set; }
        public TimeSpan LabHours { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }
    }
}