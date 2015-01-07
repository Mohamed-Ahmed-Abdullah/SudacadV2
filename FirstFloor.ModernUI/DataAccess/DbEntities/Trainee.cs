using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class Trainee : Names
    {
        private TraineeSudatel _sudatel;
        private TraineeOrganizations _traineeOrganizations;
        public int TraineeId { get; set; }
        public int AccountId { get; set; }
        public int NationalityId { get; set; }

        [Column("IdentityId")]
        [Required]
        public virtual Identity Identity { get; set; }

        [Column("JobId")]
        public virtual Job Job { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Column("TraineeSudatelId")]
        public virtual TraineeSudatel Sudatel
        {
            get { return _sudatel; }
            set { _sudatel = value; NotifyPropertyChanged(); }
        }

        [Column("TraineesOrganizationsId")]
        public virtual TraineeOrganizations TraineeOrganizations
        {
            get { return _traineeOrganizations; }
            set { _traineeOrganizations = value; NotifyPropertyChanged(); }
        }

        [Column("TraineeTypeId")]
        public virtual TraineeType TraineeType { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

}