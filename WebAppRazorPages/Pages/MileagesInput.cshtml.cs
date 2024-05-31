using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Model;
using Project.Repository;

namespace Project.Pages
{
    public class MileagesInputModel : PageModel
    {
        private readonly AppDbContext _context;
        public MileagesInputModel(AppDbContext context)
        {
            _context = context;
        }

        //[BindProperty]
        //public GradeInputModel GradeInput { get; set; }
        public List<Mileage> Mileages { get; set; }
        [BindProperty]
        public int MotocycleId { get; set; }
        public Motocycle Motocycle { get; set; }

        [BindProperty]
        public int MileageId { get; set; }
        [BindProperty]
        public int MileageMotocycle { get; set; }
        [BindProperty]
        public DateTime Date { get; set; }

        public IActionResult OnGet(int carId)
        {
            Motocycle = _context.Motocycles.FirstOrDefault(x => x.Id == carId);
            if (Motocycle == null) { return NotFound(); }
            carId = carId;
            Mileages = _context.Mileage.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var student = _context.Motocycles.FirstOrDefault(s => s.Id == MotocycleId);
            if (student == null)
            {
                return NotFound();
            }

            var subject = _context.Mileages.FirstOrDefault(s => s.Id == MileageId);
            if (subject == null)
            {
                return NotFound();
            }

            var newMileages = new Mileages
            {
                MileageMotocycle = MileageMotocycle,
                Date = Date
            };

            student.Mileages.Add(newMileages);

            _context.SaveChanges();

            return RedirectToPage("/Cars", new { carId = MotocycleId });
        }
    }
}
