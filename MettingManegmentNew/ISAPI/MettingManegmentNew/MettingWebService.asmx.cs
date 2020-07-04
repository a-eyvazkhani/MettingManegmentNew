using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using CLLMettingManegmentNew.Json;
using CLLMettingManegmentNew.Entity;
using Microsoft.SharePoint;
using BLLMettingManegmentNew;
using System.Configuration;
using System.Web.Script.Services;
using MeetingInfraStructure;

namespace MettingManegmentNew
{
    //http://dev-srv25/_vti_bin/MettingManegmentNew/MettingWebService.asmx
    [WebService]
    [System.Web.Script.Services.ScriptService]
    public class MettingWebService
    {
        private string UserNmae()
        {
            var url = ConfigurationManager.AppSettings["MMSURL"].ToString();
            var currentUserName = string.Empty;
            using (var spSite = new SPSite(url))
            {
                using (var spWeb = spSite.OpenWeb())
                {
                    currentUserName = spWeb.CurrentUser.LoginName;
                }
            }
            try
            {
                char[] char1 = new char[] { '|' };
                string[] user_login = currentUserName.Split(char1);
                currentUserName = user_login[1];
            }
            catch
            {

            }
            return currentUserName;
        }
        [WebMethod]
        public string GetCurentShamsiDate()
        {

            string result = "";

          
                result = DateTimeUtil.MiladitoPersian(DateTime.Now);
         


            return result;

        }
        [WebMethod]
        public List<MettingJson> GetAllMetting()
        {
            var result = new List<MettingJson>();
            string Fullname = UserNmae();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MettingBLL m = new MettingBLL();
                result = m.GetAllMetting(Fullname);
            });
            return result;
        }

      
        [WebMethod]
        public string SaveMetting(MettingJson _MettingJson,List<AlertJson> _AlertJson,List<MeetingUserRelJson> _MeetingUserRelJson)
        {
            var result = "";
            string Fullname = UserNmae();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MettingBLL _MettingBLL = new MettingBLL();
                _MettingBLL.SaveMetting(_MettingJson, _AlertJson, _MeetingUserRelJson);
            });
            return result;
        }

        [WebMethod]
        public List<AlertJson> GetAllAlerByMettingId(string MettingId)
        {
            var result =new List<AlertJson>(); 
            
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                AlertsBLL _AlertsBLL = new AlertsBLL();
                result= _AlertsBLL.GetAllAlerByMettingId(MettingId);
            });
            return result;
        }



        [WebMethod]
        public List<MeetingUserRelJson> GetAllMeetingUserRelId(string MettingId,string IsGetInFormed,string IsInternal)
        {
            var result = new List<MeetingUserRelJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingUserRelBLL _MeetingUserRelBLL = new MeetingUserRelBLL();
                result = _MeetingUserRelBLL.GetUserGetByMeetingId(MettingId,IsGetInFormed,IsInternal);
            });
            return result;
        }


        [WebMethod]
        public string GetCurrentTime()
        {
            string result = "";

            var date = "";
          
                date = DateTimeUtil.MiladitoPersian(DateTime.Now);
          


            var t = date.Split('/');

            var d = DateTime.Now.ToString();
            string[] spilitDateTime = d.Split(' ');
            string[] splitedTime = spilitDateTime[1].Split(':');
            string[] splitedDate = spilitDateTime[0].Split('/');

            if (spilitDateTime[2] == "PM")
            {
                switch (splitedTime[0])
                {
                    case "1":
                        splitedTime[0] = "13";
                        break;
                    case "2":
                        splitedTime[0] = "14";
                        break;
                    case "3":
                        splitedTime[0] = "15";
                        break;
                    case "4":
                        splitedTime[0] = "16";
                        break;
                    case "5":
                        splitedTime[0] = "17";
                        break;
                    case "6":
                        splitedTime[0] = "18";
                        break;
                    case "7":
                        splitedTime[0] = "19";
                        break;
                    case "8":
                        splitedTime[0] = "20";
                        break;
                    case "9":
                        splitedTime[0] = "21";
                        break;
                    case "10":
                        splitedTime[0] = "22";
                        break;
                    case "11":
                        splitedTime[0] = "23";
                        break;
                    case "12":
                        splitedTime[0] = "12";
                        break;
                }
            }

            result = splitedTime[0]+":"+ splitedTime[1];

            return result;

        }



        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public List<JsonTimeGuage> GetUserTimingGuage(string date, string usereid)
        {


            var result = new List<JsonTimeGuage>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                TimeGuageBLL _TimeGuageBLL = new TimeGuageBLL();
                result = _TimeGuageBLL.GetUserTimingGuage(date, usereid).ToList();

            });


            return result;
        }

        [WebMethod]
        public List<JsonTimeGuage> GetPlaceTimingGuage(string date, string placeid)
        {
            var result = new List<JsonTimeGuage>();

   
       


            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                TimeGuageBLL _TimeGuageBLL = new TimeGuageBLL();
                result = _TimeGuageBLL.GetPlaceTimingGuage(date, placeid).ToList();
            });

            return result;
        }




        [WebMethod]
        public List<MettingJson> GetAllMeetingWithoutMinut()
        {
            var result = new List<MettingJson>();
            string Fullname = UserNmae();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                TaskBLL _TaskBLL = new TaskBLL();
                result = _TaskBLL.GetAllMeetingWithoutMinut(Fullname);
            });
            return result;
        }


        [WebMethod]
        public List<TaskJson> GetAllTaskByMettingID(string MeetingID)
        {
            var result = new List<TaskJson>();
           
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                TaskBLL _TaskBLL = new TaskBLL();
                result = _TaskBLL.GetAllTaskByMettingID(MeetingID);
            });
            return result;
        }
        [WebMethod]
        public List<MinutesJson> GetMinutByMeetingID(string MeetingID)
        {
            var result = new List<MinutesJson>();
            
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MinutBLL _MinutBLL = new MinutBLL();
                result = _MinutBLL.GetMinutbyMeetingID(MeetingID);
            });
            return result;
        }

        [WebMethod]
        public string SaveMinut(MinutesJson MinutClass, List<TaskJson> TaskList)
        {
            var result = "";

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MinutBLL _MinutBLL = new MinutBLL();
                result = _MinutBLL.SaveMinutes(MinutClass,TaskList, UserNmae());
            });
            return result;
        }
        [WebMethod]
        public List<MeetingUserRelJson> GetAllUserUseMettingInternal(string MeetingID)
        {
            var result = new List<MeetingUserRelJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingUserRelBLL _MeetingUserRelBLL = new MeetingUserRelBLL();
                result = _MeetingUserRelBLL.GetAllUserUseMettingInternal(MeetingID, "False");
            });
            return result;
        }
        [WebMethod]
        public List<MeetingUserRelJson> GetAllUserUseMettingNotInternal(string MeetingID)
        {
            var result = new List<MeetingUserRelJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingUserRelBLL _MeetingUserRelBLL = new MeetingUserRelBLL();
                result = _MeetingUserRelBLL.GetAllUserUseMettingNotInternal(MeetingID, "True");
            });
            return result;
        }
    }
}
