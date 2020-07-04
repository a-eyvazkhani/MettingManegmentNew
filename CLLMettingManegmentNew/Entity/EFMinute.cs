using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EFMinute
    {
       
        public int NubmerMinut { get; set; }
        public Guid ID { get; set; }

        public string Title { get; set; }

        public Guid MeetingId { get; set; }

        public Guid RegistererID { get; set; }

        public string NegotiationsDescription { get; set; }

        /// <summary>
        ///    دیتابیس کانتکست  آبجکت جلسه ای که هشدار برای آن تعریف شده است 
        /// </summary>
        public virtual EfMeeting Meeting { get; set; }

        /// <summary>
        ///    دیتابیس کانتکست  آبجکت ثبت کننده صورت جلسه 
        /// </sum
        public virtual EfUser Registerer { get; set; }

        /// <summary>
        /// افراد مرتبط با صورت جلسه
        /// </summary>
       

    }
}
