using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
   public class MeetingUserRelRepository
    {
        private SEDbContext _context;
        public MeetingUserRelRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfMeetingUserRel> GetAll(Guid IdMeeting)
        {
            return _context.EfMeetingUserRel.Where(x => x.MeetingId == IdMeeting).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EfMeetingUserRel entity)
        {

            _context.EfMeetingUserRel.Add(entity);
            _context.SaveChanges();
     
        }
    }
}
