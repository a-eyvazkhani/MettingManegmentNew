using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class PhoneNumberTraslator
    {
        public PhoneNumberJson ToDomainObject(EfPhoneNumbers entity)
        {


            PhoneNumberJson _PhoneNumberJson = new PhoneNumberJson();
            _PhoneNumberJson.Title = entity.Title;
            _PhoneNumberJson.ID = entity.ID.ToString() ;
            _PhoneNumberJson.UserId = entity.UserId.ToString();
            _PhoneNumberJson.Number = entity.Number;
           
            return _PhoneNumberJson;
        }

        public List<PhoneNumberJson> ToDomainObjects(IEnumerable<EfPhoneNumbers> entities)
        {
            List<PhoneNumberJson> PhoneNumberJson = new List<PhoneNumberJson>();
            foreach (var entity in entities)
                PhoneNumberJson.Add(ToDomainObject(entity));
            return PhoneNumberJson;
        }
    }
}
