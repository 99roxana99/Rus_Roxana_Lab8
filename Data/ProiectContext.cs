﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ProiectContext : DbContext
    {
        public ProiectContext (DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect.Models.Car> Car { get; set; }

        public DbSet<Proiect.Models.Producer> Producer { get; set; }

        public DbSet<Proiect.Models.Category> Category { get; set; }
    }
}
