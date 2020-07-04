using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
  public  class AlertsRepository
    {
        private SEDbContext _context;
        public AlertsRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfAlerts> GetAllByMettingById(Guid MettingId)
        {
            return _context.EfAlert.Where(x=>x.MeetingId==MettingId).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EfAlerts entity)
        {

            _context.EfAlert.Add(entity);
            _context.SaveChanges();
            
        }
    }
}
