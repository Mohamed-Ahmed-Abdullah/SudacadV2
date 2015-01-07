using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbEntities.Base
{
    public class Names : EntityBase
    {
        [StringLength(50)]
        public string ArabicFirstName { get; set; }
        [StringLength(50)]
        public string ArabicSecondName { get; set; }
        [StringLength(50)]
        public string ArabicThirdName { get; set; }
        [StringLength(50)]
        public string ArabicLastName { get; set; }

        [StringLength(50)]
        public string EnglishFirstName { get; set; }
        [StringLength(50)]
        public string EnglishSecondName { get; set; }
        [StringLength(50)]
        public string EnglishThirdName { get; set; }
        [StringLength(50)]
        public string EnglishLastName { get; set; }
    }
}
