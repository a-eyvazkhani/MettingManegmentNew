using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class MeetingPlaceTranslator
    {
        public JsonMeetingPlaces ToDomainObject(EfMeetingPlace entity)
        {
            JsonMeetingPlaces meetingplace = new JsonMeetingPlaces();
            //meetingplace.Latitude = entity.Latitude;
            //meetingplace.Longitude = entity.Longitude;
            meetingplace.Title = entity.Title;
            meetingplace.ID = entity.ID.ToString();
            meetingplace.Bulding = entity.Building;
            meetingplace.PlaceAddress = entity.PlaceAddress;
            meetingplace.Phone = entity.Phone;

            return meetingplace;
        }

        public List<JsonMeetingPlaces> ToDomainObjects(IEnumerable<EfMeetingPlace> entities)
        {

            List<JsonMeetingPlaces> meetings = new List<JsonMeetingPlaces>();

            foreach (var entity in entities)
                meetings.Add(ToDomainObject(entity));

            return meetings;
        }
        public EfMeetingPlace Toentity(JsonMeetingPlaces domainObject)
        {
            var entity = new EfMeetingPlace();
            Fillentity(entity, domainObject);
            return entity;
        }
        public void Fillentity(EfMeetingPlace entity,JsonMeetingPlaces domainObject)
        {
            entity.ID = Guid.Parse(domainObject.ID);
            entity.Phone = domainObject.Phone;
            entity.PlaceAddress = domainObject.PlaceAddress;
            entity.Title = domainObject.Title;
            entity.Building = domainObject.Bulding;
        }
    }
}
