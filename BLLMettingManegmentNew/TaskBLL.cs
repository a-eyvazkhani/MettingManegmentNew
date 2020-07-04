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
   public class TaskBLL
    {
        public List<MettingJson> GetAllMeetingWithoutMinut(string fullQualifyName)
        {
            var result = new List<MettingJson>();
            UserBLL userbll = new UserBLL();
            var UserLogin = userbll.GetByFullQualify(fullQualifyName);
           
            MettingRepository _MettingRepository = new MettingRepository();
            MeetingTranslator _MeetingTranslator = new MeetingTranslator();
            result = _MeetingTranslator.ToDomainObjects(_MettingRepository.GetAll(Guid.Parse(UserLogin.ID)).Where(x=>x.HaveMinuts==false&&x.DateMetting<=DateTime.Now));
         
          
            return result;
            
        }
        public List<TaskJson> GetAllTaskByMettingID(string MeetingID)
        {
            var result = new List<TaskJson>();
            

            TaskRepository _TaskRepository = new TaskRepository();
            TaskTranslator _TaskTranslator = new TaskTranslator();
            result = _TaskTranslator.ToDomainObjects(_TaskRepository.GetAllTaskByMettingId(Guid.Parse(MeetingID)));


            return result;

        }
    }
}
