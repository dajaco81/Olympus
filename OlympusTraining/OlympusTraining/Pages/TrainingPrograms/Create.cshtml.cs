using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlympusTraining.Data;
using OlympusTraining.Models;

namespace OlympusTraining.Pages.TrainingPrograms
{
    public class CreateModel : PageModel
    {
        private readonly OlympusTraining.Data.OlympusTrainingContext _context;

        public CreateModel(OlympusTraining.Data.OlympusTrainingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrainingProgram TrainingProgram { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TrainingProgram == null || TrainingProgram == null)
            {
                return Page();
            }

            _context.TrainingProgram.Add(TrainingProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
