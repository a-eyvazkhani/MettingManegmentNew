using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EfPhoneNumbers
    {
        public Guid ID { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست عنوان شماره تلفن     
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست شماره ی شماره تلفن     
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///    دیتابیس کانتکست نوع  شماره تلفن موبایل یا خط ثابت     
        /// </summary>
        public int Type { get; set; }


        /// <summary>
        ///   دیتابیس کانتکست آیدی کاربر  شماره تلفن     
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست آیدی شرکت  شماره تلفن     
        /// </summary>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// پیش فرض
        /// </summary>
        public bool IsDefault { get; set; }


        public virtual EfUser User { get; set; }


    }
}
