using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class Room : Lookup
    {
        public RoomType RoomType { get; set; }
    }

    public enum RoomType
    {
        None = 0,
        Lecture = 1,
        Lab = 2,
    }
}