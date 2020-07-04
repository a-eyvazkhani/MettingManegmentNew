using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLLMettingManegmentNew.Entity;

namespace DBMettingManegmentNew
{
  public  class MettingRepository
    {
        private SEDbContext _context;
        public MettingRepository()
        {
            _context= new SEDbContext();
        }
        public List<EfMeeting> GetAll(Guid Id)
        {
            return _context.EfMeetings.Where(x => x.SecretaryUserId == Id).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }

        public void Add(EfMeeting entity)
        {
           
            _context.EfMeetings.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(EfMeeting entity)
        {
            _context.EfMeetings.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(EfMeeting entity)
        {
            //var efMeetingRels = _context.MeetingUserRel.Where(x => x.MeetingId == (Guid)prmDomainObject.ID);
            //foreach (var rel in efMeetingRels)
            //    _context.MeetingUserRel.Remove(rel);
            var entityFind = _context.EfMeetings.Find(entity.ID);
            _context.SaveChanges();

            //_context.EfMeetings.Add(entity);

        }
        public IEnumerable<EfMeeting> GetByDateAndUserID(DateTime date, Guid id)
        {
            var meetingDate = date.Date;
            var meetings = _context.EfMeetings.Where(x => x.DateMetting == meetingDate).ToList();
            var entities = new List<EfMeeting>();

            foreach (var meeting in meetings)
            {
                //foreach (var user in meeting.RelatedUsers)
                //{
                //    if (user.UserID == (Guid)id)
                //    {
                        entities.Add(meeting);
                //    }
                //}
            }
            return entities;
        }

        public List<EfMeeting> GetMeetingsByDateAndPlaceID(DateTime date, Guid id)
        {
            var meetingDate = date.Date;
            var meetings = _context.EfMeetings.Where(x => x.DateMetting == meetingDate && x.PlaceID==id).ToList();
           
            return meetings;
        }



    }
}
