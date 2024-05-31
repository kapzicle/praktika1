using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.Repository
{
    public class SqlMotocycleRepository : IMotocycle
    {
        private readonly AppDbContext _appDbContext;

        public SqlMotocycleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Motocycle Add(Motocycle Imotocycle)
        {
            return Imotocycle;
        }
        public Motocycle DeleteMotocycle(int Id)
        {
            var motocycle = GetMotocycle(Id);
            _appDbContext.Remove(motocycle);
            _appDbContext.SaveChanges();
            return motocycle;
        }

        public Motocycle? GetMotocycle(int Id)
        {
            return _appDbContext.Motocycles.Where(u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Motocycle> GetAll()
        {
            return _appDbContext.Motocycles.ToList();
        }

        public Motocycle UpdateMotocycle(Motocycle upMotocycle)
        {
            if (upMotocycle.Id == 0)
            {
                _appDbContext.Motocycles.Add(upMotocycle);
            }
            else
            {
                _appDbContext.Motocycles.Update(upMotocycle);
            }
            _appDbContext.SaveChanges();
            return upMotocycle;
        }
    }
}
