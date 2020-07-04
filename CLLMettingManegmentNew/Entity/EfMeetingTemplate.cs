using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
   public class EfMeetingTemplate
    {
        public Guid ID { get; set; }


        /// <summary>
        ///  دیتابیس کانتکست عنوان  
        /// </summary>
        public string Title { get; set; }

    }
}
