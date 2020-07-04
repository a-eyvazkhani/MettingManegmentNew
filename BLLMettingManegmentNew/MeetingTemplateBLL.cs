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
   public class MeetingTemplateBLL
    {
        public List<MeetingTemplateJson> GetAllUnit()
        {
            var result = new List<MeetingTemplateJson>();
            MeetingTemplateRepository _MeetingTemplateRepository = new MeetingTemplateRepository();
            MeetingTemplateTranslator _UnitTranslator = new MeetingTemplateTranslator();
            result = _UnitTranslator.ToDomainObjects(_MeetingTemplateRepository.GetAll());
            return result;
        }
    }
}
