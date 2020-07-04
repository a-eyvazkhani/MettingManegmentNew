using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
   public class MeetingUserRelJson
    {
        public MeetingUserRelJson()
        {
            User = new UserJson();
            IsGetInFormed = "false";
        }
        public string UserId { get; set; }
        public string MeetingId { get; set; }

        public string IsGetInFormed { get; set; }

        public string ID { get; set; }

        public string IsPersent { get; set; }

        public UserJson User { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }

        public string Email { get; set; }

        public string IsInternal { get; set; }

        public string Department { get; set; }

       
    }
}
