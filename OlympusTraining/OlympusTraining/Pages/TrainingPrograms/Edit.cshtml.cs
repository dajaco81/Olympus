using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OlympusTraining.Data;
using OlympusTraining.Models;

namespace OlympusTraining.Pages.TrainingPrograms
{
    public class EditModel : PageModel
    {
        private readonly OlympusTraining.Data.OlympusTrainingContext _context;

        public EditModel(OlympusTraining.Data.OlympusTrainingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingProgram TrainingProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TrainingProgram == null)
            {
                return NotFound();
            }

            var trainingprogram =  await _context.TrainingProgram.FirstOrDefaultAsync(m => m.Id == id);
            if (trainingprogram == null)
            {
                return NotFound();
            }
            TrainingProgram = trainingprogram;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TrainingProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingProgramExists(TrainingProgram.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrainingProgramExists(int id)
        {
          return (_context.TrainingProgram?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
