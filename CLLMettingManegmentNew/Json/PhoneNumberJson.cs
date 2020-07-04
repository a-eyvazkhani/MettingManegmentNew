using MeetingInfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
   public class PhoneNumberJson
    {
        /// <summary>
        /// عنوان شماره تلفن
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// نوع شماره تلفن ثابت یا موبایل
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// آیدی  شخص  
        /// </summary>
        public string UserId { get; set; }

        public string ID { get; set; }
        /// <summary>
        /// آیدی   شرکت 
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// پیش فرض
        /// </summary>
        public bool IsDefualt { get; set; }


        /// <summary>
        /// مشخص می کند که آیا تلفن برای شخص است یا شرکت 
        /// </summary>
       
    }
}
