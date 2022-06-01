using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OlympusTraining.Models;

namespace OlympusTraining.Data
{
    public class OlympusTrainingContext : DbContext
    {
        public OlympusTrainingContext (DbContextOptions<OlympusTrainingContext> options)
            : base(options)
        {
        }

        public DbSet<OlympusTraining.Models.Activity>? Activity { get; set; }

        public DbSet<OlympusTraining.Models.TrainingProgram>? TrainingProgram { get; set; }
    }
}
