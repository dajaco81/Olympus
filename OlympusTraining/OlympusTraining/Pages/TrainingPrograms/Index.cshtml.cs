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
    public class IndexModel : PageModel
    {
        private readonly OlympusTraining.Data.OlympusTrainingContext _context;

        public IndexModel(OlympusTraining.Data.OlympusTrainingContext context)
        {
            _context = context;
        }

        public IList<TrainingProgram> TrainingProgram { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TrainingProgram != null)
            {
                TrainingProgram = await _context.TrainingProgram.ToListAsync();
            }
        }
    }
}
