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
   public class AlertsBLL
    {
        public List<AlertJson> GetAllAlerByMettingId(string MettingId)
        {
            var result = new List<AlertJson>();
            AlertsRepository _AlertsRepository = new AlertsRepository();
            AlertTranslator _AlertTranslator = new AlertTranslator();
            result = _AlertTranslator.ToDomainObjects(_AlertsRepository.GetAllByMettingById(Guid.Parse(MettingId)));
            int shomare = 1;
            foreach(AlertJson alert in result)
            {
                alert.ID = shomare.ToString();
                if (alert.AlarmType == "1")
                    alert.AlarmType = "SMS";
                else
                    alert.AlarmType = "Email";
                shomare++;
            }
            return result;
        }
    }
}
