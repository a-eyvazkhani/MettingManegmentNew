using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EfUnit
    {
        /// <summary>
        ///   دیتابیس کانتکست شناسه قالب جلسه 
        /// </summary>
        public Guid ID { get; set; }


        /// <summary>
        ///  دیتابیس کانتکست عنوان  
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// دیتابیس کانتکست نام
        /// </summary>


        /// <summary>
        /// دیتابیس کانتکست گروههای دسترسی
        /// </summary>
        public string AccessGroups { get; set; }
        public virtual ICollection<EfTask> Task { get; set; }
    

    }
}
