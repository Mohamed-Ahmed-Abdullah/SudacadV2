﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities.Base;

namespace DataAccess.DbEntities
{
    public class BatchTrainee : DiscountBase
    {
        public Trainee Trainee { get; set; }
    }
}