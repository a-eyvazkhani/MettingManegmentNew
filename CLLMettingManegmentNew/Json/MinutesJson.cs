using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
    public class MinutesJson
    {
        public MinutesJson()
        {
            MettingJson = new MettingJson();
        }
        public string ID { get; set; }

        public string Title { get; set; }

        public string MeetingId { get; set; }

        public string NegotiationsDescription { get; set; }

        public string RegistererID { get; set; }

        public string NubmerMinut { get; set; }

        public string RegistererFullName { get; set; }

        public MettingJson MettingJson { get; set; }
    }
}
