using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class Motocycle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите марку машины")] 
        public string BrandMotocycle { get; set; }
        [Required(ErrorMessage = "Введите модель")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Введите тип двигателя")]
        public string EngineMotocycle { get; set; }
        public List<Mileages> Mileages { get; set; }

        public Motocycle() 
        {
            BrandMotocycle ??= string.Empty;
            Model ??= string.Empty;
            EngineMotocycle ??= string.Empty;
            Mileages ??= new();
        }
    }
}