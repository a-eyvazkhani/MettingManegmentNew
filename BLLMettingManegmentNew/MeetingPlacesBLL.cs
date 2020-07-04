using CLLMettingManegmentNew.Json;
using CLLMettingManegmentNew.Translators;
using DBMettingManegmentNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLMettingManegmentNew
{
   public class MeetingPlacesBLL
    {
        public List<JsonMeetingPlaces> GetAll()
        {
            UserBLL userbll = new UserBLL();
            
            var result = new List<JsonMeetingPlaces>();
           MeetingPlacesRepository _MeetingPlacesRepository = new MeetingPlacesRepository();
            MeetingPlaceTranslator _MeetingPlaceTranslator = new MeetingPlaceTranslator();
            result = _MeetingPlaceTranslator.ToDomainObjects(_MeetingPlacesRepository.GetAll());
            return result;
        }
        public string SaveMeetingPlace(JsonMeetingPlaces _MeetingPlace)
        {
            string result = string.Empty;

            MeetingPlacesRepository _MeetingPlacesRepository = new MeetingPlacesRepository();
            MeetingPlaceTranslator _MeetingPlaceTranslator = new MeetingPlaceTranslator();

            if(_MeetingPlace.ID == "")
            {
                _MeetingPlace.ID = Guid.NewGuid().ToString();
                _MeetingPlacesRepository.Add(_MeetingPlaceTranslator.Toentity(_MeetingPlace));
            }
            else
            {
                _MeetingPlacesRepository.Update(_MeetingPlaceTranslator.Toentity(_MeetingPlace));
            }
            return result;
        }
        public string DeleteMeetingPlace(JsonMeetingPlaces _MeetingPlaceCLL)
        {
            string result = string.Empty;

            MeetingPlacesRepository _MeetingPlacesRepository = new MeetingPlacesRepository();
            MeetingPlaceTranslator _MeetingPlaceTranslator = new MeetingPlaceTranslator();

            if (_MeetingPlaceCLL.ID != "")
            {
                _MeetingPlacesRepository.Delete(_MeetingPlaceTranslator.Toentity(_MeetingPlaceCLL));                
            }

            return result;

        }
    }
}
