using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbEntities.Base
{
    public abstract class DiscountBase : EntityBase
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
    }
}
