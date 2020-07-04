using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
    public class EfMeeting
    {
        public EfMeeting()
        {
            RelatedUsers = new List<EfMeetingUserRel>();
            Alerts = new List<EfAlerts>();
        }




        public Guid ID { get; set; }
        /// <summary>
        /// دیتابیس کانتکست عنوان جلسه
        /// </summary>
        public string Title { get; set; }

        public string TarikhSabt { get; set; }


        /// <summary>
        /// دیتابیس کانتکست تاریخ ثبت جلسه
        /// </summary>
        public DateTime DateSabt { get; set; }

        public string TarikhMetting { get; set; }
        ///// <summary>
        ///// دیتابیس کانتکست تاریخ  جلسه
        ///// </summary>
        public DateTime DateMetting { get; set; }


        /// <summary>
        /// دیتابیس کانتکست زمان شروع جلسه
        /// </summary>
        public string StartTime { get; set; }


        /// <summary>
        /// دیتابیس کانتکست زمان  پایان جلسه
        /// </summary>
        public string FinishTime { get; set; }


        ///// <summary>
        ///// دیتابیس کانتکست توضیحات جلسه
        ///// </summary>
        public string Description { get; set; }


        /// <summary>
        /// دیتابیس کانتکست آیا جلسه صورت جلسه دارد ؟
        /// </summary>
        public bool HaveMinuts { get; set; }




        ///// <summary>
        ///// دیتابیس کانتکست آیا جلسه لغو شده است ؟
        ///// </summary>
        public bool IsRevoke { get; set; }







        /// <summary>
        /// دیتابیس کانتکست لیست هشدار های جلسه 
        /// </summary>
        public virtual ICollection<EfAlerts> Alerts { get; set; }


        ///// <summary>
        ///// دیتابیس کانتکست مکان برگزاری جلسه 
        ///// </summary>
        public virtual EfMeetingPlace Place { get; set; }


        ///// <summary>
        ///// دیتابیس کانتکست آیدی مکان برگزاری جلسه 
        ///// </summary>
        public Guid PlaceID { get; set; }


        ///// <summary>
        ///// جلسه حذف شده 
        ///// </summary>
        public bool IsDeleted { get; set; }


        ///// <summary>
        ///// وضعیت برگزاری 
        ///// </summary>
        public bool IsHeld { get; set; }

        ///// <summary>
        ///// دیتابیس کانتکست لیست دستورجلسات جلسه    
        ///// </summary>
        public string Agenda { get; set; }



        ///// <summary>
        ///// دیتابیس کانتکست لیست ضمایم جلسه
        ///// </summary>
        //public virtual ICollection<EfDocument> Attachments { get; set; }


        ///// <summary>
        ///// دیتابیس کانتکست دبیر جلسه
        ///// </summary>
        public virtual EfUser Secretary { get; set; }

        ///// <summary>
        ///// دیتابیس کانتکست ثبت کننده جلسه
        ///// </summary>
        public virtual EfUser RegistrerUser { get; set; }

        ///// <summary>
        ///// دیتابیس کانتکست آیدی دبیر جلسه
        ///// </summary>
        public Guid SecretaryUserId { get; set; }

        ///// <summary>
        ///// دیتابیس کانتکست آیدی ثبت کننده جلسه
        ///// </summary>
        public Guid RegistrerUserId { get; set; }
        ///// <summary>
        ///// افراد مرتبط با جلسه
        ///// </summary>
        public ICollection<EfMeetingUserRel> RelatedUsers { get; set; }


        ///// <summary>
        /////    دیتابیس کانتکست  آبجکت جلسه ای که هشدار برای آن تعریف شده است 
        ///// </summary>
        //public virtual ICollection<EFMinute> Minute { get; set; }

        //public virtual ICollection<EFMMSTask> Tasks { get; set; }

        //public virtual ICollection<EfMMSAssignment> Assignments { get; set; }


        public virtual EfMeetingTemplate MeetingTemplate { get; set; }

        ///// <summary>
        ///// دیتابیس کانتکست ثبت کننده جلسه
        ///// </summary>
        public virtual EfUnit Unit { get; set; }


        public Guid MeetingTemplateID { get; set; }

        ///// <summary>
        ///// دیتابیس کانتکست آیدی ثبت کننده جلسه
        ///// </summary>
        public Guid UnitID { get; set; }

        public Guid ParentGroh { get; set; }

        public virtual ICollection<EfTask> Task { get; set; }
    }
}
