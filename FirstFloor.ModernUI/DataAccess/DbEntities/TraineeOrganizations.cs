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
    public class TraineeOrganizations : JustId
    {
        [Column("OrganizationTypeId")]
        public virtual OrganizationType OrganizationType { get; set; }

        [Column("OrganizationId")]
        public virtual Organization Organization { get; set; }

        [StringLength(200)]
        public string CoordinatorName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}