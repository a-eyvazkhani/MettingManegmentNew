using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
   public class MeetingPlacesRepository
    {
        private SEDbContext _context;
        public MeetingPlacesRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfMeetingPlace> GetAll()
        {
            return _context.EfMeetingPlace.ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EfMeetingPlace entity)
        {
            _context.EfMeetingPlace.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(EfMeetingPlace entity)
        {
            _context.EfMeetingPlace.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(EfMeetingPlace entity)
        {
            var entityfind = _context.EfMeetingPlace.Find(entity.ID);
            _context.SaveChanges();
        }
    }
}
