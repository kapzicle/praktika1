using Project.Model;

namespace Project.Repository
{
    public interface IMotocycle
    {
        public Motocycle Add(Motocycle Imotocycle);
        public Motocycle? GetMotocycle(int Id);
        public List<Motocycle> GetAll();
        public Motocycle UpdateMotocycle(Motocycle upMotocycle);
        public Motocycle DeleteMotocycle(int Id);
    }
}
