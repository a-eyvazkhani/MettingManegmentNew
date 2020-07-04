using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EfTask
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public Guid UnitID { get; set; }

        public DateTime StartDate { get; set; }

        public Guid MeetingId { get; set; }

        public int EstimatedTimeHore { get; set; }

        public int EstimatedTimeMin { get; set; }

        public int EstimatedTimeSumMinut { get; set; }

        public Guid MasolAnjamID { get; set; }

        public Guid Aprove1ID { get; set; }

        //public Guid Aprove2ID { get; set; }

        //public Guid Aprove3ID { get; set; }
        //public Guid Aprove4ID { get; set; }

        public int IsCarent { get; set; }

        public int Persent { get; set; }

        public int StatusSave { get; set; }

        public string TarikhStart { get; set; }


        public virtual EfUser MasolAnjam { get; set; }
        public virtual EfUser Aprove1 { get; set; }

        //public virtual EfUser Aprove2 { get; set; }
        //public virtual EfUser Aprove3 { get; set; }
        //public virtual EfUser Aprove4 { get; set; }
        public virtual EfMeeting Meetings { get; set; }

        public virtual EfUnit Unit { get; set; }
    }
}
