using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
  public  class MeetingTemplateRepository
    {
        private SEDbContext _context;
        public MeetingTemplateRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfMeetingTemplate> GetAll()
        {
            return _context.EfMeetingTemplate.ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EfMeetingTemplate entity)
        {
            _context.EfMeetingTemplate.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(EfMeetingTemplate entity)
        {
            _context.EfMeetingTemplate.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(EfMeetingTemplate entity)
        {
            var entityfind = _context.EfMeetingTemplate.Find(entity.ID);
            _context.SaveChanges();
        }
    }
}
