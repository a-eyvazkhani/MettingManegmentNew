using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class TaskTranslator
    {
        public TaskJson ToDomainObject(EfTask entity)
        {
            TaskJson _TaskJson = new TaskJson();
            _TaskJson.ID = entity.ID.ToString();
            _TaskJson.Title = entity.Title;
            _TaskJson.UnitID = entity.UnitID.ToString();
            _TaskJson.MeetingID = entity.MeetingId.ToString();
            _TaskJson.EstimatedTimeHore = entity.EstimatedTimeHore.ToString();
            _TaskJson.EstimatedTimeMin = entity.EstimatedTimeMin.ToString();
          //  _TaskJson.EstimatedTimeMin = ((entity.EstimatedTimeHore * 60) + entity.EstimatedTimeMin).ToString();
            _TaskJson.EstimatedTimeText = _TaskJson.EstimatedTimeHore + "." + _TaskJson.EstimatedTimeMin;
            _TaskJson.MasolAnjamFullName= new UserTranslator().ToDomainObject(entity.MasolAnjam).FullName;
            _TaskJson.Aprove1IDFullName = new UserTranslator().ToDomainObject(entity.Aprove1).FullName;
            _TaskJson.MasolAnjamID = entity.MasolAnjam.ToString();
            _TaskJson.Aprove1ID = entity.Aprove1ID.ToString();
            //_TaskJson.Aprove2ID = entity.Aprove2ID.ToString();
            //_TaskJson.Aprove3ID = entity.Aprove3ID.ToString();
            //_TaskJson.Aprove4ID = entity.Aprove4ID.ToString();
            _TaskJson.IsCarent = entity.IsCarent.ToString();
            _TaskJson.Persent = entity.Persent.ToString();
            _TaskJson.StatusSave = entity.StatusSave.ToString();
            _TaskJson.TarikhStart = entity.TarikhStart.ToString();


        


            return _TaskJson;

        }

        public List<TaskJson> ToDomainObjects(List<EfTask> entities)
        {

            List<TaskJson> ListUserJson = new List<TaskJson>();

            foreach (var entity in entities)
                ListUserJson.Add(ToDomainObject(entity));

            return ListUserJson;
        }
        public EfTask ToEntity(TaskJson domainObject)
        {
            var entity = new EfTask();
            FillEntity(entity, domainObject);
            return entity;
        }
        public void FillEntity(EfTask entity, TaskJson domainObject)
        {

            entity.ID = Guid.Parse(domainObject.ID);
            entity.Title = domainObject.Title;
            entity.UnitID = Guid.Parse(domainObject.UnitID);
            entity.StartDate = DateTime.Parse(domainObject.StartDate);
            entity.MeetingId = Guid.Parse(domainObject.MeetingID);
            entity.EstimatedTimeHore = int.Parse(domainObject.EstimatedTimeHore);
            entity.EstimatedTimeMin = int.Parse(domainObject.EstimatedTimeMin);

            entity.EstimatedTimeSumMinut=((entity.EstimatedTimeHore*60)+entity.EstimatedTimeMin);
            entity.MasolAnjamID = Guid.Parse(domainObject.MasolAnjamID);
            entity.Aprove1ID = Guid.Parse(domainObject.Aprove1ID);
            //if(entity.Aprove2ID!=null)
            //{
            //    entity.Aprove2ID = Guid.Parse(domainObject.Aprove2ID);
            //}
            //if (entity.Aprove3ID != null)
            //{
            //    entity.Aprove3ID = Guid.Parse(domainObject.Aprove3ID);
            //}
            //if (entity.Aprove4ID != null)
            //{
            //    entity.Aprove4ID = Guid.Parse(domainObject.Aprove4ID);
            //}
            entity.IsCarent = int.Parse(domainObject.IsCarent);
            entity.Persent = int.Parse(domainObject.Persent);
            entity.StatusSave = int.Parse(domainObject.StatusSave);
            entity.TarikhStart = domainObject.TarikhStart;







        }
    }
}
