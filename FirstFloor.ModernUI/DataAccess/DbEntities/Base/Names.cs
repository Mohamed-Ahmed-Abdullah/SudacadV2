using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbEntities.Base
{
    public class Names : JustId
    {
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
