﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroes.Models
{
    public class SuperHero
    {
        [Key]
        public int SuperId { get; set; }
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryPower { get; set; }
        public string SecondaryPower { get; set; }
        public string CatchPhrase { get; set; }
    }
}