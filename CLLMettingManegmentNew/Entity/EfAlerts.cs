using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
    public class EfAlerts
    {
        public Guid ID { get; set; }


        public string Title { get; set; }


        public DateTime AlarmDate { get; set; }

        public string AlarmTarikh { get; set; }

        public string SaatErsal { get; set; }





        public int AlarmType { get; set; }


        public Guid MeetingId { get; set; }



        public bool IsSent { get; set; }


        public Guid UserID { get; set; }

        /// <summary>
        /// وضعیت ارسال
        /// </summary>
        public string SendStatus { get; set; }

        public int AlertOrCansel { get; set; }


        public virtual EfMeeting Meeting { get; set; }



        /// <summary>
        ///    دیتابیس کانتکست  آبجکت جلسه ای که هشدار برای آن تعریف شده است 
        /// </summary>
        public virtual EfUser User { get; set; }
    }
}
