using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EfMeetingUserRel
    {
        public Guid ID { get; set; }

        public Guid MeetingId { get; set; }

        public Guid UserID { get; set; }

        /// <summary>
        /// ایا کاربر جزء مطلعین است یا دعوت شده به جلسه است.
        /// </summary>
        public bool IsGetInFormed { get; set; }

        public bool IsPersent { get; set; }

        public virtual EfMeeting Meeting { get; set; }

        public virtual EfUser User { get; set; }

      //  public virtual EfEmail Email { get; set; }


    }
}
