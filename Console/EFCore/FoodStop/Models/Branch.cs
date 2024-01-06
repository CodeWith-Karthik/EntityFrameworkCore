﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStop.Models
{
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public long Phone { get; set; }
    }
}
