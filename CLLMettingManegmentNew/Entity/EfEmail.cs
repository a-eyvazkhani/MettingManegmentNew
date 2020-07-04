using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
    public class EfEmail
    {
        public Guid ID { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست عنوان ایمیل     
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست آدرس ایمیل     
        /// </summary>
        public string EmailAddress { get; set; }


        /// <summary>
        ///   دیتابیس کانتکست آیدی موجودیت شخص  ایمیل     
        /// </summary>
        public Guid? UserId { get; set; }

        public EfUser User { get; set; }
    }
}
