using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
    public class MettingJson
    {
        public MettingJson()
        {
            Alerts = new List<AlertJson>();
            InnerUsers = new List<UserJson>();
            OuterUsers = new List<UserJson>();
            GetInformeds = new List<UserJson>();
            UnitJson = new UnitJson();
            MeetingTemplateJson = new MeetingTemplateJson();
            //Documents = new List<JsonDocument>();
        }

        public int RowNumber { get; set; }
        public string ID { get; set; }
        public string Title { get; set; }
        public string RegDate { get; set; }
        public string MeetingDate { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string Description { get; set; }
        public bool HaveMinuts { get; set; }
        public bool IsRevoke { get; set; }
        public string PlaceID { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceTitle { get; set; }
        public string SecretaryUserId { get; set; }
        
        public string RegistrerUserID { get; set; }
        public string RegistrerFullName { get; set; }
        public string SecretaryFullName { get; set; }
        public string Agenda { get; set; }
        public string Statuse { get; set; }
        public string Minut { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsHeld { get; set; }

        public bool SendEmailNow { get; set; }
        public bool SendSmsNow { get; set; }

        public string TarikhSabt { get; set; }
        public string TarikhMetting { get; set; }


        public string MeetingTemplateID { get; set; }
        public string UnitID { get; set; }

        public string ParentGroh { get; set; }

        public List<AlertJson> Alerts { get; set; }
        public List<UserJson> InnerUsers { get; set; }
        public List<UserJson> OuterUsers { get; set; }
        public List<UserJson> GetInformeds { get; set; }

        public MeetingTemplateJson MeetingTemplateJson { get; set; }
        public UnitJson UnitJson { get; set; }

    }
}
