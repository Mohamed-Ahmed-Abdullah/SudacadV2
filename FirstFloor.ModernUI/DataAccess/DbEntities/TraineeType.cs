using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class TraineeType : Lookup
    {
    }

    public enum TraineeTypeEnum
    {
        Individual = 1,
        Sudatel = 2,
        Organization = 3,
    }
}