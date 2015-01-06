using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbEntities
{
    public class Identity
    {
        public int IdentityId { get; set; }

        [Column("IdentityTypeId")]
        //[Index("IX_IdentityTypeAndIdentityNumber", 1, IsUnique = true)]
        public virtual IdentityType IdentityType { get; set; }

        //[Index("IX_IdentityTypeAndIdentityNumber", 2, IsUnique = true)]
        public string IdentityNumber { get; set; }

        [Column("NationalityId")]
        public virtual Nationality Nationality { get; set; }

        public DateTime? IssueDate { get; set; }

        public override string ToString()
        {
            return (Nationality == null ? "" : Nationality.ArabicName) +
                   " " + (IdentityType == null ? "" : IdentityType.ArabicName) +
                   " " + IdentityNumber +
                   " " + (IssueDate == null ? "" : IssueDate.Value.ToString("dd MMM yyyy"));
        }
    }
}
