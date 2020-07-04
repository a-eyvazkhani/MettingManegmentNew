using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class MeetingTranslator
    {
     

        public MettingJson ToDomainObject(EfMeeting entity)
        {
            MettingJson meeting = new MettingJson();
            meeting.ID = entity.ID.ToString();
            meeting.Title = entity.Title;
            meeting.Description = entity.Description;
            meeting.FinishTime = entity.FinishTime;
            meeting.StartTime = entity.StartTime;
            meeting.HaveMinuts = entity.HaveMinuts;
          //  meeting.MeetingDate = entity.MeetingDate.;
            meeting.PlaceAddress = new MeetingPlaceTranslator().ToDomainObject(entity.Place).PlaceAddress;
            meeting.PlaceID = new MeetingPlaceTranslator().ToDomainObject(entity.Place).ID;
            // meeting.RegDate = entity.RegDate;
            meeting.SecretaryFullName = new UserTranslator().ToDomainObject(entity.Secretary).UserName;
            meeting.SecretaryUserId = new UserTranslator().ToDomainObject(entity.Secretary).ID;
           meeting.RegistrerUserID = new UserTranslator().ToDomainObject(entity.RegistrerUser).ID;
            meeting.TarikhMetting = entity.TarikhMetting;
           
            meeting.RegistrerFullName = new UserTranslator().ToDomainObject(entity.RegistrerUser).UserName;
            meeting.TarikhSabt = entity.TarikhSabt;

            meeting.UnitID = new UnitTranslator().ToDomainObject(entity.Unit).ID;
            meeting.MeetingTemplateID = new MeetingTemplateTranslator().ToDomainObject(entity.MeetingTemplate).ID;

            //  meeting.AddAttachments(new DocumentTranslator().ToDomainObjects(entity.Attachments));
            meeting.Agenda = entity.Agenda;
           // meeting.AddAlerts(new AlertTranslator().ToDomainObjects(entity.Alerts));
            meeting.IsHeld = entity.IsHeld;
            //if (entity.IsRevoke)
            //    meeting.RevokeMeeting();

            //foreach (var relUser in entity.RelatedUsers)
            //{
            //    var user = new UserTranslator().ToDomainObject(relUser.User);
            //    if (relUser.IsGetInFormed)
            //        meeting.AddGetinformed(user);
            //    else
            //        meeting.Addinvited(user);
            //}

            return meeting;

        }

        public List<MettingJson> ToDomainObjects(IEnumerable<EfMeeting> entities)
        {

            List<MettingJson> meetings = new List<MettingJson>();
           
            foreach (var entity in entities)
                meetings.Add(ToDomainObject(entity));

            return meetings;
        }

        public EfMeeting ToEntity(MettingJson domainObject)
        {
            var entity = new EfMeeting();
            FillEntity(entity, domainObject);
            return entity;
        }
        public void FillEntity(EfMeeting entity, MettingJson domainObject)
        {

            entity.ID = Guid.Parse(domainObject.ID);
            entity.Title = domainObject.Title;
            entity.Description = domainObject.Description;
            entity.FinishTime = domainObject.FinishTime;
            entity.StartTime = domainObject.StartTime;
            entity.HaveMinuts = domainObject.HaveMinuts;
            entity.TarikhSabt = domainObject.TarikhSabt;
            entity.TarikhMetting = domainObject.TarikhMetting;
            entity.DateSabt = DateTime.Parse(domainObject.MeetingDate) ;
            entity.PlaceID = Guid.Parse(domainObject.PlaceID);
       
            entity.IsRevoke = domainObject.IsRevoke;
            entity.IsDeleted = domainObject.IsDeleted;
            entity.Agenda = domainObject.Agenda;
            entity.IsHeld = domainObject.IsHeld;

            //foreach (var user in domainObject.Inviteds)

            //    entity.RelatedUsers.Add(new EfMeetingUserRel() { ID = Guid.NewGuid(), MeetingId = (Guid)domainObject.ID, UserID = (Guid)user.ID, IsGetInFormed = false });

            //foreach (var user in domainObject.Getinformeds)
            //    entity.RelatedUsers.Add(new EfMeetingUserRel() { ID = Guid.NewGuid(), MeetingId = (Guid)domainObject.ID, UserID = (Guid)user.ID, IsGetInFormed = true });


            entity.SecretaryUserId = Guid.Parse(domainObject.SecretaryUserId);

            entity.RegistrerUserId = Guid.Parse(domainObject.RegistrerUserID);
            entity.MeetingTemplateID = Guid.Parse(domainObject.MeetingTemplateID);
            entity.UnitID = Guid.Parse(domainObject.UnitID);
        }

        //public IEnumerable<EfMeeting> ToEntities(IEnumerable<Meeting> meetings)
        //{
        //    var entities = new List<EfMeeting>();
        //    foreach (var meeting in meetings)
        //        entities.Add(ToEntity(meeting));
        //    return entities;
        //}
    }
}
