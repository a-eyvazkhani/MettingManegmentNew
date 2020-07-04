using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class MeetingTemplateTranslator
    {
        public MeetingTemplateJson ToDomainObject(EfMeetingTemplate entity)
        {
         

            MeetingTemplateJson _MeetingTemplateJson = new MeetingTemplateJson();
            _MeetingTemplateJson.Title = entity.Title;
            _MeetingTemplateJson.ID = entity.ID.ToString();

            return _MeetingTemplateJson;
        }

        public List<MeetingTemplateJson> ToDomainObjects(List<EfMeetingTemplate> entities)
        {
            List<MeetingTemplateJson> meetingtemplate = new List<MeetingTemplateJson>();
            foreach (var entity in entities)
                meetingtemplate.Add(ToDomainObject(entity));
            return meetingtemplate;
        }

    }
}
