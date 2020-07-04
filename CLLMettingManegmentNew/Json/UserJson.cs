using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Json
{
    public class UserJson
    {
        public UserJson()
        {
            PhoneNumberJson = new PhoneNumberJson();
            EmailJson = new EmailJson();
        }
        public int RowNumber { get; set; }

        public string ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public string Mobile { get; set; }

        public string CompanyId { get; set; }

        public string FullName { get; set; }

        public bool Isinternal { get; set; }

        public PhoneNumberJson PhoneNumberJson { get; set; }

        public EmailJson EmailJson { get; set; }



    }
}
