using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
   public class MinutRepository
    {
        private SEDbContext _context;
        public MinutRepository()
        {
            _context = new SEDbContext();
        }
        public List<EFMinute> GetAll(Guid Id)
        {
            return _context.EFMinute.Where(x => x.MeetingId == Id).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EFMinute entity)
        {
            try
            {
                entity.NubmerMinut = _context.EFMinute.Max(x => x.NubmerMinut) + 1;
            }
            catch
            {
                entity.NubmerMinut = 1;
            }
            _context.EFMinute.Add(entity);
            _context.SaveChanges();
        }
        public void Update(EFMinute entity)
        {
            //var efMeetingRels = _context.MeetingUserRel.Where(x => x.MeetingId == (Guid)prmDomainObject.ID);
            //foreach (var rel in efMeetingRels)
            //    _context.MeetingUserRel.Remove(rel);
            var entityFind = _context.EFMinute.Find(entity.ID);
            _context.SaveChanges();

            //_context.EfMeetings.Add(entity);

        }
    }
}
