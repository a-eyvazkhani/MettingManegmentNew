using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
    public class EfUser
    {

        public Guid ID { get; set; }


        /// <summary>
        /// نام کامل کاربر که به همراه دامنه می باشد
        /// نام کامل کاربر خارجی شامل نام ونام خانوادگی می باشد.
        /// </summary>
        public string FullQualifyName { get; set; }




        /// <summary>
        ///   دیتابیس کانتکست نام  کاربر        
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        ///   دیتابیس کانتکست نام خانوادگی  کاربر        
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        ///   دیتابیس کانتکست نام کاربری  کاربر        
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// دیتابیس کانتکست دپارتمان  کاربر   
        /// </summary>
        public string Department { get; set; }


        /// <summary>
        /// دیتابیس کانتکست عنوان کاری  کاربر   
        /// </summary>
        public string JobTitle { get; set; }


        /// <summary>
        /// دیتابیس کانتکست داخلی یا خارجی بودن کاربر
        /// </summary>
        public bool IsInternal { get; set; }

        /// <summary>
        /// عنوان یا پری فیکس
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// کدملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// حذف منطقی شدن
        /// </summary>
        public bool IsDeleted { get; set; }

        public virtual ICollection<EfPhoneNumbers> Mobiles { get; set; }


        /// <summary>
        /// دیتابیس کانتکست ایمیل کاربر
        /// </summary>
        public virtual ICollection<EfEmail> Emails { get; set; }


        /// <summary>
        /// دیتابیس کانتکست ایمیل کاربر
        /// </summary>

 


        public virtual ICollection<EfMeetingUserRel> MeetingUserRels { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<EfMeeting> SecretryMeetings { get; set; }

        public virtual ICollection<EfAlerts> Alerts { get; set; }


        /// <summary>
        /// 
        /// </summary>
        //public virtual ICollection<EFMinutUserRel> MinutUserRel { get; set; }


        /// <summary>
        /// 
        /// </summary>
       // public virtual ICollection<MeetingManagement.Entities.EfMMSAssignment> MeetingAssignments { get; set; }


        public virtual ICollection<EFMinute> MinutRegisterer { get; set; }
        public virtual ICollection<EfTask> MasolAnjam { get; set; }

        public virtual ICollection<EfTask> Aprove1 { get; set; }

        //public virtual ICollection<EfTask> Aprove2 { get; set; }

        //public virtual ICollection<EfTask> Aprove3 { get; set; }

        //public virtual ICollection<EfTask> Aprove4 { get; set; }





        /// <summary>
        /// 
        /// </summary>





    }
}
