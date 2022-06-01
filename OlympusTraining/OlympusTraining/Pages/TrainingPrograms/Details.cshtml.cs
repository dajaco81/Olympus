using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OlympusTraining.Data;
using OlympusTraining.Models;

namespace OlympusTraining.Pages.TrainingPrograms
{
    public class DetailsModel : PageModel
    {
        private readonly OlympusTraining.Data.OlympusTrainingContext _context;

        public DetailsModel(OlympusTraining.Data.OlympusTrainingContext context)
        {
            _context = context;
        }

      public TrainingProgram TrainingProgram { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TrainingProgram == null)
            {
                return NotFound();
            }

            var trainingprogram = await _context.TrainingProgram.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingprogram == null)
            {
                return NotFound();
            }
            else 
            {
                TrainingProgram = trainingprogram;
            }
            return Page();
        }
    }
}
