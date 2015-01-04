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
    public class TraineeSudatel : JustId
    {
        [Column("DivisionId")]
        public virtual Division Division { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(10)]
        public string SudatelEmployeeId { get; set; }
    }
}