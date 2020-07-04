using CLLMettingManegmentNew.Json;
using CLLMettingManegmentNew.Translators;
using DBMettingManegmentNew;
using MeetingInfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLMettingManegmentNew
{
    public class MinutBLL
    {
        public List<MinutesJson> GetMinutbyMeetingID(string MeetingId)
        {
            var result = new List<MinutesJson>();



            MinutRepository _MinutRepository = new MinutRepository();
            MinutTranslator _MinutTranslator = new MinutTranslator();
            result = _MinutTranslator.ToDomainObjects(_MinutRepository.GetAll(Guid.Parse(MeetingId)));


            return result;

        }
        public string SaveMinutes(MinutesJson MinutClass, List<TaskJson> TaskList,string fullQualifyName)
        {
            string Result = "";
            UserBLL userbll = new UserBLL();
            string UserLogin = userbll.GetByFullQualify(fullQualifyName).ID;
            MinutRepository _MinutRepository = new MinutRepository();
            MinutTranslator _MinutTranslator = new MinutTranslator();

            if (MinutClass.ID == "")
            {
                MinutClass.ID = Guid.NewGuid().ToString();
                MinutClass.RegistererID = UserLogin;
               _MinutRepository.Add(_MinutTranslator.ToEntity(MinutClass));
                addTask(TaskList);
            }
            else
            {
                MinutClass.RegistererID = UserLogin;
                _MinutRepository.Update(_MinutTranslator.ToEntity(MinutClass));
                DeliteTask(TaskList);
                addTask(TaskList);
            }
           
            return Result;
        }
        public void addTask(List<TaskJson> TaskList)
        {
            TaskRepository _TaskRepository = new TaskRepository();
            TaskTranslator _TaskTranslator = new TaskTranslator();
            foreach (TaskJson Taskjson in TaskList)
            {
                Taskjson.ID = Guid.NewGuid().ToString();
                Taskjson.StartDate= Utilities.GetMiladiDate(Taskjson.TarikhStart).ToString();
                Taskjson.EstimatedTimeHore = Taskjson.EstimatedTimeText.Split('.')[0];
                Taskjson.EstimatedTimeMin = "0";
                _TaskRepository.Add(_TaskTranslator.ToEntity(Taskjson));
            }
        }
        public void DeliteTask(List<TaskJson> TaskList)
        {
            TaskRepository _TaskRepository = new TaskRepository();
            TaskTranslator _TaskTranslator = new TaskTranslator();
            foreach (TaskJson Taskjson in TaskList)
            {
                if(Taskjson.ID!=null)
                _TaskRepository.ChekhDelitByID(Guid.Parse(Taskjson.ID));
            }
        }


    }
}
