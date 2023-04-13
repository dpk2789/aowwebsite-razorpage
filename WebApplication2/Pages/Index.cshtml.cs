using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure;
using WebApplication2.ViewModels;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CmsContext _context;

        public IndexModel(CmsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PagesViewModel? PagesViewModel { get; set; }

        public async Task OnGetAsync()
        {
            var data = await _context.CmsPages.ToListAsync();
            if (data.Count > 1)
            {
                PagesViewModel = await _context.CmsPages.Select(p => new PagesViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Body = p.Body,
                }).FirstOrDefaultAsync();
            }
        }
    }
}