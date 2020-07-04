using MeetingInfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
    public class AlertJson
    {
        public AlertJson()
        {
            User = new UserJson();
        }
        public int RowNumber { get; set; }
        public string ID { get; set; }
        public string Title { get; set; }
        public string AlarmDate { get; set; }
        public string AlarmTarikh { get; set; }
        public string SaatErsal { get; set; }
        public string AlarmType { get; set; }
        public string MeetingId { get; set; }
        public string IsSent { get; set; }
        public string UserID { get; set; }
        public string SendStatus { get; set; }
        public string AlertOrCansel { get; set; }

        public string FullName { get; set; }

        public string DatabaseOrErsalOrHoshdar { get; set; }



        public UserJson User { get; set; }

    }
}
