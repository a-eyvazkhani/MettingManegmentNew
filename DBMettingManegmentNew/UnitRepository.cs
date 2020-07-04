using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
  public class UnitRepository
    {
         private SEDbContext _context;
        public UnitRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfUnit> GetAll()
        {
            return _context.EfUnit.ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EfUnit entity)
        {
            _context.EfUnit.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(EfUnit entity)
        {
            _context.EfUnit.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(EfUnit entity)
        {
            var entityfind = _context.EfUnit.Find(entity.ID);
            _context.SaveChanges();
        }
    }
}
