using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace DBMettingManegmentNew
{
    public class UserRepository
    {
        private SEDbContext _context;
        public UserRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfUser> GetAll_Internal()
        {
            return _context.EfUsers.Where(x => x.IsInternal == true).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public List<EfUser> GetAll_Outer()
        {
            return _context.EfUsers.Where(x => x.IsInternal == false).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public EfUser GetByFullQualify(string fullQualifyName)
        {
            return _context.EfUsers.Where(x => x.FullQualifyName == fullQualifyName).FirstOrDefault();
            //if (fullQualifyName == "SHAREPOINT\\system")
            //    EfCurrentUser = DefaultQuery().FirstOrDefault(x => x.FullQualifyName == fullQualifyName);
            //if ((fullQualifyName == "SHAREPOINT\\system") && (EfCurrentUser == null))
            //    EfCurrentUser = _context.EfUsers.FirstOrDefault(x => x.FullQualifyName == fullQualifyName);
            //if (fullQualifyName != "SHAREPOINT\\system")
            //    EfCurrentUser = DefaultQuery().FirstOrDefault(x => x.FullQualifyName == fullQualifyName);


        }
        public List<EfUser> Get(Guid Id)
        {
            return _context.EfUsers.ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }

        //private IQueryable<EfUser> DefaultQuery()
        //{
        //    return _context.EfUsers.
        //        Include(d => d.Emails).
        //        Include(m => m.Mobiles).


        //        Where(e => !e.IsDeleted);

        //}


    }
}
