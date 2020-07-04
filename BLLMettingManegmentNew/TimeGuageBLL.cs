using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingInfraStructure;
using DBMettingManegmentNew;
using CLLMettingManegmentNew.Translators;

namespace BLLMettingManegmentNew
{
   public class TimeGuageBLL
    {
        public List<JsonTimeGuage> GetUserTimingGuage(string date, string usereid)
        {
            List<JsonTimeGuage> result = new List<JsonTimeGuage>();

            List<MettingJson> MettingJson = null;

            var meetingdate = DateTime.Now;


            meetingdate = DateTimeUtil.PersiantoMiladi(date).Date;


          
                MettingRepository _MettingRepository = new MettingRepository();
             MeetingTranslator _MeetingTranslator = new MeetingTranslator();
            MettingJson = _MeetingTranslator.ToDomainObjects( _MettingRepository.GetByDateAndUserID(meetingdate, Guid.Parse(usereid)).ToList());

          

            foreach (var meeting in MettingJson)
            {
                var timeobject = new JsonTimeGuage();


                timeobject.from = DateTimeUtil.ConvertStringTopercent(meeting.StartTime);
                timeobject.to = DateTimeUtil.ConvertStringTopercent(meeting.FinishTime);


                timeobject.color = "#c20000";

                result.Add(timeobject);
            }

            return result;
        }


        public List<JsonTimeGuage> GetPlaceTimingGuage(string date, string usereid)
        {
            List<JsonTimeGuage> result = new List<JsonTimeGuage>();

            List<MettingJson> MettingJson = null;

            var meetingdate = DateTime.Now;


            meetingdate = DateTimeUtil.PersiantoMiladi(date).Date;



            MettingRepository _MettingRepository = new MettingRepository();
            MeetingTranslator _MeetingTranslator = new MeetingTranslator();
            MettingJson = _MeetingTranslator.ToDomainObjects(_MettingRepository.GetMeetingsByDateAndPlaceID(meetingdate, Guid.Parse(usereid)).ToList());



            foreach (var meeting in MettingJson)
            {
                var timeobject = new JsonTimeGuage();


                timeobject.from = DateTimeUtil.ConvertStringTopercent(meeting.StartTime);
                timeobject.to = DateTimeUtil.ConvertStringTopercent(meeting.FinishTime);


                timeobject.color = "#c20000";

                result.Add(timeobject);
            }

            return result;
        }








    }
}
