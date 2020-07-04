using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class EmailTranslator
    {
        public EmailJson ToDomainObject(EfEmail entity)
        {


            EmailJson _EmailJson = new EmailJson();
            _EmailJson.EmailAddress = entity.EmailAddress;
            _EmailJson.UserId = entity.UserId.ToString();


            return _EmailJson;
        }

        public List<EmailJson> ToDomainObjects(IEnumerable<EfEmail> entities)
        {
            List<EmailJson> PhoneNumberJson = new List<EmailJson>();
            foreach (var entity in entities)
                PhoneNumberJson.Add(ToDomainObject(entity));
            return PhoneNumberJson;
        }
    }
}
