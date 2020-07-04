using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EfMeetingPlace
    {
        public Guid ID { get; set; }


        /// <summary>
        ///دیتابیس کانتکست عنوان مکان جلسه
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        ///دیتابیس کانتکست نام ساختمان مکان جلسه
        /// </summary>
        public string Building { get; set; }


        /// <summary>
        ///دیتابیس کانتکست عرض جغرافیایی مکان جلسه
        /// </summary>
        //public decimal Latitude { get; set; }


        ///// <summary>
        /////دیتابیس کانتکست طول جغرافیایی مکان جلسه
        ///// </summary>
        //public decimal Longitude { get; set; }


        /// <summary>
        ///دیتابیس کانتکست شماره تلفن مان جلسه
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        ///دیتابیس کانتکست آدرس مکان جلسه
        /// </summary>
        public string PlaceAddress { get; set; }


        public virtual ICollection<EfMeeting> Meeting { get; set; }
    }
}
