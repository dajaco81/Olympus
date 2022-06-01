using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OlympusTraining.Data;
using OlympusTraining.Models;

namespace OlympusTraining.Pages.Activities
{
    public class DeleteModel : PageModel
    {
        private readonly OlympusTraining.Data.OlympusTrainingContext _context;

        public DeleteModel(OlympusTraining.Data.OlympusTrainingContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Activity Activity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Activity == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity.FirstOrDefaultAsync(m => m.Id == id);

            if (activity == null)
            {
                return NotFound();
            }
            else 
            {
                Activity = activity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Activity == null)
            {
                return NotFound();
            }
            var activity = await _context.Activity.FindAsync(id);

            if (activity != null)
            {
                Activity = activity;
                _context.Activity.Remove(Activity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
