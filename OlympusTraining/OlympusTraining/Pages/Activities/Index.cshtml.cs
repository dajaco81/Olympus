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
    public class IndexModel : PageModel
    {
        private readonly OlympusTraining.Data.OlympusTrainingContext _context;

        public IndexModel(OlympusTraining.Data.OlympusTrainingContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Activity != null)
            {
                Activity = await _context.Activity.ToListAsync();
            }
        }
    }
}
