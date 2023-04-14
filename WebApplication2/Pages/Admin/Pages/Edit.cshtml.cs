using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure;
using WebApplication2.ViewModels;

namespace WebApplication2.Pages.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly CmsContext _context;

        public EditModel(CmsContext context)
        {
            _context = context;
        }

       
        public EditPageViewModel? EditPageViewModel { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.CmsPages.ToListAsync();
            if (data.Count > 0)
            {
                EditPageViewModel = await _context.CmsPages.Where(x => x.Id == id).Select(p => new EditPageViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Body = p.Body,
                }).FirstOrDefaultAsync();
            }

            return Page();
        }      
        public async Task<IActionResult> OnPostAsync(EditPageViewModel viewModel)
        {
            try
            {

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {

            }


            return Page();
        }
    }
}
