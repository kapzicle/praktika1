using Project.Model;

namespace Project.Repository
{
    public class MocMotocycleRepository : IMotocycle
    {
        private List<Motocycle> _motocycles;
        public MocMotocycleRepository() 
        {
            //if (_cars == null) _cars = new List<Car>(); эта строчка равно строчке 11
            _motocycles ??= new List<Motocycle>();
            _motocycles.Add(new() { Id = 1, BrandMotocycle = "Ауди", Model = "RS6" , EngineMotocycle = "Бензиновый"});
            _motocycles.Add(new() { Id = 2, BrandMotocycle = "BMW", Model = "E-39", EngineMotocycle = "Бензиновый" });
            _motocycles.Add(new() { Id = 3, BrandMotocycle = "Nissan", Model = "Primera P11", EngineMotocycle = "Бензиновый"});
        }
        public Motocycle Add(Motocycle Imotocycle)
        {
            _motocycles.Add(Imotocycle);
            return Imotocycle;
        }

        public Motocycle DeleteMotocycle(int Id)
        {
            var motocycle = GetMotocycle(Id);
            _motocycles.Remove(motocycle);
            return motocycle;
        }

        public Motocycle? GetMotocycle(int Id) 
        {
            return _motocycles.Where(u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Motocycle> GetAll() 
        {
            return _motocycles;
        }

        public Motocycle UpdateMotocycle(Motocycle upMotocycle)
        {
            var motocycleDB = GetMotocycle(upMotocycle.Id);
            if (motocycleDB != null)
            {
                _motocycles.Remove(motocycleDB);
            }
            _motocycles.Add(upMotocycle);
            return upMotocycle;
        }

    }
}
