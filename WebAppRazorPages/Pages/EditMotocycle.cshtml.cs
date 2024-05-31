using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Model;
using Project.Repository;

namespace Project.Pages
{
    [Authorize]
    public class EditMotocycleModel : PageModel
    {
        public EditMotocycleModel(IMotocycle MotocycleRepository)
        {
            _MotocycleRepository = MotocycleRepository;
        }

        private IMotocycle _MotocycleRepository;
        public Motocycle? Motocycle { get; set; }

        public IActionResult OnGet(int id)
        {
            Motocycle = _MotocycleRepository.GetMotocycle(id);
            Motocycle ??= new();
            return Page();
        }

        public IActionResult OnPost(Motocycle CarForm)
        {
            Motocycle = _MotocycleRepository.UpdateMotocycle(CarForm);

            if (Motocycle == null) return NotFound();

            return RedirectToPage("Motocycles");
        }
    }
}