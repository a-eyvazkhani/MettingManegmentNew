using CLLMettingManegmentNew.Json;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using BLLMettingManegmentNew;

namespace MettingManegmentNew
{
    [WebService]
    [System.Web.Script.Services.ScriptService]
    public class SettingWebService
    {



        [WebMethod]
        public List<UserJson> GetAllUserInternal()
        {
            var result = new List<UserJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                UserBLL _UserBLL = new UserBLL();
                result = _UserBLL.GetAllUserInternal();
            });
            return result;
        }
        [WebMethod]
        public List<UserJson> GetAllUserOuter()
        {
            var result = new List<UserJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                UserBLL _UserBLL = new UserBLL();
                result = _UserBLL.GetAllUserOuter();
            });
            return result;
        }

       

        [WebMethod]
        public List<UnitJson> GetAllUnitJson()
        {
            var result = new List<UnitJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                UnitBLL _UnitBLL = new UnitBLL();
                result = _UnitBLL.GetAllUnit();
            });
            return result;
        }
        [WebMethod]
        public List<MeetingTemplateJson> GetAllMeetingTemplate()
        {
            var result = new List<MeetingTemplateJson>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingTemplateBLL _MeetingTemplateBLL = new MeetingTemplateBLL();
                result = _MeetingTemplateBLL.GetAllUnit();
            });
            return result;
        }
        [WebMethod]
        public List<JsonMeetingPlaces> GetAllMeetingPlaces()
        {
            var result = new List<JsonMeetingPlaces>();
            
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingPlacesBLL _MeetingPlacesBLL = new MeetingPlacesBLL();
                result = _MeetingPlacesBLL.GetAll();
            });
            return result;
        }
        [WebMethod]
        public string AddMeetingPlace(JsonMeetingPlaces _MeetingPlace)
        {
            var result = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingPlacesBLL _MeetingPlacesBLL = new MeetingPlacesBLL();
                _MeetingPlacesBLL.SaveMeetingPlace(_MeetingPlace);
            });
            return result;
        }
        [WebMethod]
        public string DeletePlace(string placeId)
        {
            var result = string.Empty;

            JsonMeetingPlaces _MeetingPlaceCLL = new JsonMeetingPlaces();        
            _MeetingPlaceCLL.ID = placeId;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                MeetingPlacesBLL _MeetingPlacesBLL = new MeetingPlacesBLL();
                _MeetingPlacesBLL.DeleteMeetingPlace(_MeetingPlaceCLL);
                
            });
            return result;
        }
        [WebMethod]
        public List<UserJson> GetAllUser()
        {
            var result = new List<UserJson>();            

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                UserBLL _Userbll = new UserBLL();
                result = _Userbll.GetAllUserInternal();
            });

            return result;

        }
        [WebMethod]
        public List<JsonAdmins> GetAllAdmins()
        {
            var result = new List<JsonAdmins>();

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                AdminsBLL _AdminsBLl = new AdminsBLL();
                result = _AdminsBLl.GetAll();
            });

            return result;
        }
        [WebMethod]
        public string AddAdmins(JsonAdmins _AdminsGroup)
        {
            var result = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                AdminsBLL _AdminsBLl = new AdminsBLL();
                _AdminsBLl.AddAdmin(_AdminsGroup);                
            });

            return result;

        }

    }
}
