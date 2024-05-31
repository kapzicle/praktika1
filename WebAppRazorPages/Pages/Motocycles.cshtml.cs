using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Repository;
using Project.Model;
using Microsoft.AspNetCore.Authorization;

namespace Project.Pages
{
    [Authorize]
    public class MotocyclesModel : PageModel
    {
        public MotocyclesModel(IMotocycle motocycleRepository) 
        {
            _motocycleRepository = motocycleRepository;
        }
        private IMotocycle _motocycleRepository;
        public List<Motocycle> motocycles { get; set; }
        public IActionResult OnGet()
        {
            motocycles = _motocycleRepository.GetAll();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _motocycleRepository.DeleteMotocycle(id);
            return RedirectToPage();
        }
    }
}
