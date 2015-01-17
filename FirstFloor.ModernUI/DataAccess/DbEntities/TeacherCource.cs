using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class TeacherCource : EntityBase
    {
        public int Id { get; set; }

        [Column("CourseId")]
        public virtual Course Course { get; set; }

        //teacher will say i will teach this cource by this Price
        public decimal Price { get; set; }
    }
}