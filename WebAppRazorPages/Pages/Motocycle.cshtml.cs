using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Repository;
using Project.Model;
using Microsoft.AspNetCore.Authorization;

namespace Project.Pages
{
    [Authorize]
    public class MotocycleModel : PageModel
    {
        public MotocycleModel(IMotocycle motocycleRepository)
        {
            _motocycleRepository = motocycleRepository;
        }
        private IMotocycle _motocycleRepository;
        public Motocycle? Motocycle { get; set; }
        public IActionResult OnGet(int id_motocycle)
        {
            Motocycle = _motocycleRepository.GetMotocycle(id_motocycle);
            if (Motocycle == null) return NotFound(); 
            return Page();
        }
    }
}
