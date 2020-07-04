using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Entity
{
    public class EfAdmins
    {
        public Guid ID { get; set; }


        /// <summary>
        /// نام کامل کاربر که به همراه دامنه می باشد       
        /// </summary>
        public Guid IDUser { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست نام  کاربر        
        /// </summary>
        ///   
        public string UserName { get; set; }

        /// <summary>
        ///   دیتابیس کانتکست نام  کاربر        
        /// </summary>
        ///   
        public virtual EfUser UserID { get; set; }
    }
}
