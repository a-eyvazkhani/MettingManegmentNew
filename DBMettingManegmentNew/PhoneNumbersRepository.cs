using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
   public class PhoneNumbersRepository
    {
        private SEDbContext _context;
        public PhoneNumbersRepository()
        {
            _context = new SEDbContext();
        }
        public EfPhoneNumbers GetByUserId(Guid UserId)
        {
            return _context.EfPhoneNumbers.Where(x=>x.UserId==UserId).FirstOrDefault();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
    }
}
