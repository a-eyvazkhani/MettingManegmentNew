using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class MeetingUserRelTranslator
    {
        public MeetingUserRelJson ToDomainObject(EfMeetingUserRel entity)
        {


            MeetingUserRelJson _MeetingUserRelJson = new MeetingUserRelJson();
            _MeetingUserRelJson.ID = entity.ID.ToString();
            _MeetingUserRelJson.UserId = entity.UserID.ToString();
            _MeetingUserRelJson.IsGetInFormed = entity.IsGetInFormed.ToString();
            _MeetingUserRelJson.IsPersent = entity.IsPersent.ToString();
            _MeetingUserRelJson.MeetingId = entity.MeetingId.ToString();
            _MeetingUserRelJson.User = new UserTranslator().ToDomainObject(entity.User);
            _MeetingUserRelJson.FullName= new UserTranslator().ToDomainObject(entity.User).FullName;
            _MeetingUserRelJson.Mobile = new UserTranslator().ToDomainObject(entity.User).Mobile;
            _MeetingUserRelJson.Email = new UserTranslator().ToDomainObject(entity.User).Email;
            _MeetingUserRelJson.IsInternal = new UserTranslator().ToDomainObject(entity.User).Isinternal.ToString();
            _MeetingUserRelJson.Department = new UserTranslator().ToDomainObject(entity.User).Department;



            return _MeetingUserRelJson;
        }

        public List<MeetingUserRelJson> ToDomainObjects(List<EfMeetingUserRel> entities)
        {
            List<MeetingUserRelJson> _MeetingUserRelJson = new List<MeetingUserRelJson>();
            foreach (var entity in entities)
                _MeetingUserRelJson.Add(ToDomainObject(entity));
            return _MeetingUserRelJson;
        }

        public EfMeetingUserRel ToEntity(MeetingUserRelJson domainObject)
        {
            var entity = new EfMeetingUserRel();
            FillEntity(entity, domainObject);
            return entity;
        }
        public void FillEntity(EfMeetingUserRel entity, MeetingUserRelJson domainObject)
        {

            entity.ID = Guid.Parse(domainObject.ID);
            entity.UserID = Guid.Parse(domainObject.UserId);
            entity.IsGetInFormed = bool.Parse(domainObject.IsGetInFormed);
             entity.MeetingId = Guid.Parse(domainObject.MeetingId);
            entity.IsPersent = bool.Parse(domainObject.IsPersent);

        }
    }
}
