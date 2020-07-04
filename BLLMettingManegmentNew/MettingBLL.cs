using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using Microsoft.SharePoint;
using DBMettingManegmentNew;
using CLLMettingManegmentNew.Translators;
using MeetingInfraStructure;

namespace BLLMettingManegmentNew
{
   public class MettingBLL
    {
        public List<MettingJson> GetAllMetting(string fullQualifyName)
        {
            UserBLL userbll = new UserBLL();
            var UserLogin = userbll.GetByFullQualify(fullQualifyName);
            var result = new List<MettingJson>();
            MettingRepository _MettingRepository = new MettingRepository();
            MeetingTranslator _MeetingTranslator = new MeetingTranslator();
            result = _MeetingTranslator.ToDomainObjects(_MettingRepository.GetAll(Guid.Parse(UserLogin.ID)));
            return result;
        }
        public string SaveMetting(MettingJson _MettingJson,List<AlertJson>ListAlertJson,List<MeetingUserRelJson> MeetingUserRelJson)
        {
            string result = "";
            MettingRepository _MettingRepository = new MettingRepository();
            MeetingTranslator _MeetingTranslator = new MeetingTranslator();
           
            if (_MettingJson.ID == "")
            {
                _MettingJson.ID = Guid.NewGuid().ToString();
                _MettingJson.MeetingDate = DateTime.Now.ToString();
                _MettingJson.TarikhSabt = Utilities.GetPersianDate(DateTime.Now);
                _MettingJson.ParentGroh = _MettingJson.ID;
                _MettingJson.TarikhMetting = _MettingJson.TarikhMetting;
               
                _MettingRepository.Add(_MeetingTranslator.ToEntity(_MettingJson));
                AddMeetingUserRel(MeetingUserRelJson, _MettingJson);
                addAlertMetting(ListAlertJson, _MettingJson);
            }
            else
            {
                _MettingJson.TarikhSabt = Utilities.GetPersianDate(DateTime.Now);
                _MettingJson.ParentGroh = _MettingJson.ID;
                _MettingJson.MeetingDate = DateTime.Now.ToString();
                _MettingJson.TarikhMetting = _MettingJson.TarikhMetting;

                _MettingRepository.Update(_MeetingTranslator.ToEntity(_MettingJson));
                AddMeetingUserRel(MeetingUserRelJson, _MettingJson);
                addAlertMetting(ListAlertJson, _MettingJson);
            }

            return result;
        }

        public void addAlertMetting(List<AlertJson>listalert,MettingJson _MettingJson)
        {
            foreach (AlertJson _AlertJson in listalert)
            {
                _AlertJson.MeetingId = _MettingJson.ID;
                _AlertJson.ID = Guid.NewGuid().ToString();
                _AlertJson.IsSent = "false";
                _AlertJson.AlertOrCansel = "1";
                _AlertJson.AlarmDate = Utilities.GetMiladiDate(_AlertJson.AlarmTarikh).ToString();
                _AlertJson.SendStatus = "ثبت شده";
                if(_AlertJson.AlarmType=="SMS")
                {
                    _AlertJson.AlarmType = "1";
                }
                else
                {
                    _AlertJson.AlarmType = "2";
                }
                if(_AlertJson.DatabaseOrErsalOrHoshdar!="1")
                {
                    AlertTranslator _AlertTranslator = new AlertTranslator();
                    AlertsRepository _AlertsRepository = new AlertsRepository();

                    _AlertsRepository.Add(_AlertTranslator.ToEntity(_AlertJson));
                }
                

            }
            
        }


        public void AddMeetingUserRel(List<MeetingUserRelJson> MeetingUserRel,MettingJson MettingJson)
        {
            foreach(MeetingUserRelJson _MeetingUserRelJson in MeetingUserRel)
            {
                _MeetingUserRelJson.MeetingId = MettingJson.ID;
                _MeetingUserRelJson.UserId = _MeetingUserRelJson.ID;
                _MeetingUserRelJson.ID = Guid.NewGuid().ToString();
                MeetingUserRelTranslator _MeetingTranslator = new MeetingUserRelTranslator();
                MeetingUserRelRepository _MeetingUserRelRepository = new MeetingUserRelRepository();

                _MeetingUserRelRepository.Add(_MeetingTranslator.ToEntity(_MeetingUserRelJson));


            }
        }
    }
}
