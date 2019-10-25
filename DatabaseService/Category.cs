﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseService
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
    }
}

