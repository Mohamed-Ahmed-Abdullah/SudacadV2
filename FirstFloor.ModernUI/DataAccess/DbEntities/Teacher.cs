using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.DbEntities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbEntities
{
    public class Teacher : Names
    {

        [Key]
        public int TeacherId { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Column("IdentityId")]
        [Required]
        public virtual Identity Identity { get; set; }

        public virtual List<Attachment> Attachments { get; set; }

        //each cource and his price for that cource, 
        //you should see the cource price when you start entering this
      
        private ObservableCollection<TeacherCource> _cources;
        public virtual ObservableCollection<TeacherCource> Cources
        {
            get { return _cources; }
            set { _cources = value; NotifyPropertyChanged(); }
        }
    }
}