using OlympusTraining.Data;
using Microsoft.EntityFrameworkCore;

namespace OlympusTraining.Models
{
    public static class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new OlympusTrainingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OlympusTrainingContext>>())) 
            {
                if (context == null || context.TrainingProgram == null)
                {
                    throw new ArgumentNullException("Null OlympusTrainingContext");
                }

                if (context.TrainingProgram.Any())
                {
                    return;
                }

                context.TrainingProgram.AddRange(
                    new TrainingProgram
                    {
                        Id = 0,
                        Goal = "POWER",
                        Archetype = "MAXIMUM STRENGTH",
                        Style = "WEIGHT TRAINING",
                        Option = 1,
                        Diet = "ADD DIET PLAN FOR $29.99, RECIEVE ONE-TIME 15% OFF CODE FOR ALL COURSES",
                        Info = "UNIMPLEMENTED",
                        Price = 78.98M
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
