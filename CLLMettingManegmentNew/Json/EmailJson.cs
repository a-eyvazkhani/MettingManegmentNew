
using MeetingInfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
  public  class EmailJson
    {
        public string Title { get; set; }

        /// <summary>
        /// آدرس 
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// آیدی  شخص  
        /// </summary>
        public object UserId { get; set; }

        /// <summary>
        /// آیدی   شرکت 
        /// </summary>
        public object CompanyId { get; set; }


        /// <summary>
        /// ایمیل پیش فرض
        /// </summary>
        public bool IsDefualt { get; set; }


        /// <summary>
        /// مشخص می کند که آیا  برای شخص است یا شرکت 
        /// </summary>
     
    }
}
