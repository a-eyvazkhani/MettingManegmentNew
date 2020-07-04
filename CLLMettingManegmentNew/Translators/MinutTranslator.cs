using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class MinutTranslator
    {
        public MinutesJson ToDomainObject(EFMinute entity)
        {
            MinutesJson _MinutesJson = new MinutesJson();
            _MinutesJson.ID = entity.ID.ToString();
            _MinutesJson.Title = entity.Title;
            _MinutesJson.NegotiationsDescription = entity.NegotiationsDescription;
            _MinutesJson.NubmerMinut = entity.NubmerMinut.ToString();
            _MinutesJson.RegistererID = entity.RegistererID.ToString();
            _MinutesJson.RegistererFullName = new UserTranslator().ToDomainObject(entity.Registerer).UserName;
            _MinutesJson.MeetingId = entity.MeetingId.ToString();
            _MinutesJson.MettingJson= new MeetingTranslator().ToDomainObject(entity.Meeting);








            return _MinutesJson;

        }

        public List<MinutesJson> ToDomainObjects(IEnumerable<EFMinute> entities)
        {

            List<MinutesJson> meetings = new List<MinutesJson>();

            foreach (var entity in entities)
                meetings.Add(ToDomainObject(entity));

            return meetings;
        }

        public EFMinute ToEntity(MinutesJson domainObject)
        {
            var entity = new EFMinute();
            FillEntity(entity, domainObject);
            return entity;
        }
        public void FillEntity(EFMinute entity, MinutesJson domainObject)
        {

            entity.ID = Guid.Parse(domainObject.ID);
            entity.Title = domainObject.Title;
            entity.MeetingId = Guid.Parse(domainObject.MeetingId);
            entity.NegotiationsDescription = domainObject.NegotiationsDescription;
            entity.RegistererID = Guid.Parse(domainObject.RegistererID);
            
        

          

       
        }
    }
}
