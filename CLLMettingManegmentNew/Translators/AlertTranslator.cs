using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class AlertTranslator
    {
        public AlertJson ToDomainObject(EfAlerts entity)
        {
            AlertJson _AlertJson = new AlertJson();
            _AlertJson.ID = entity.ID.ToString();
            _AlertJson.Title = entity.Title;
            _AlertJson.AlarmDate = entity.AlarmDate.ToString();
            _AlertJson.AlarmTarikh = entity.AlarmTarikh;
            _AlertJson.SaatErsal = entity.SaatErsal;
            _AlertJson.AlarmType = entity.AlarmType.ToString();
            _AlertJson.MeetingId = entity.MeetingId.ToString();
            _AlertJson.IsSent = entity.IsSent.ToString();
            _AlertJson.UserID = new UserTranslator().ToDomainObject(entity.User).ID;
            _AlertJson.User = new UserTranslator().ToDomainObject(entity.User);
            _AlertJson.SendStatus = entity.SendStatus.ToString();
            _AlertJson.AlertOrCansel = entity.AlertOrCansel.ToString();
            _AlertJson.FullName = new UserTranslator().ToDomainObject(entity.User).FullName;


            return _AlertJson;

        }

        public List<AlertJson> ToDomainObjects(List<EfAlerts> entities)
        {

            List<AlertJson> ListUserJson = new List<AlertJson>();

            foreach (var entity in entities)
                ListUserJson.Add(ToDomainObject(entity));

            return ListUserJson;
        }
        public EfAlerts ToEntity(AlertJson domainObject)
        {
            var entity = new EfAlerts();
            FillEntity(entity, domainObject);
            return entity;
        }
        public void FillEntity(EfAlerts entity, AlertJson domainObject)
        {

            entity.ID = Guid.Parse(domainObject.ID);
            entity.Title = domainObject.Title;
            entity.UserID = Guid.Parse(domainObject.UserID);
            entity.AlarmDate = DateTime.Parse(domainObject.AlarmDate);
            entity.AlarmTarikh = domainObject.AlarmTarikh;
            entity.SaatErsal = domainObject.SaatErsal;
            entity.AlarmType = int.Parse(domainObject.AlarmType);
            entity.MeetingId = Guid.Parse(domainObject.MeetingId);
            entity.IsSent = bool.Parse(domainObject.IsSent);
            entity.SendStatus = domainObject.SendStatus;
            entity.AlertOrCansel = int.Parse(domainObject.AlertOrCansel);




        }
    }
}
