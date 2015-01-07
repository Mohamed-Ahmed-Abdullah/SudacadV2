using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class Attachment : EntityBase
    {
        public int AttachmentId { get; set; }

        [StringLength(250)]
        public string FileName { get; set; }

        public byte[] File { get; set; }
    }
}