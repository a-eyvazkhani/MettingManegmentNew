using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using CLLMettingManegmentNew.Translators;
using DBMettingManegmentNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLMettingManegmentNew
{
    public class UserBLL
    {
        public UserJson GetByFullQualify(string fullQualifyName)
        {
            var result = new UserJson();
            UserRepository _UserRepository = new UserRepository();
            UserTranslator _UserTranslator = new UserTranslator();
            result = _UserTranslator.ToDomainObject(_UserRepository.GetByFullQualify(fullQualifyName));
            return result;
        }
        public List<UserJson> GetAllUserInternal()
        {
            var result = new List<UserJson>();
            UserRepository _UserRepository = new UserRepository();
            UserTranslator _UserTranslator = new UserTranslator();
            result = _UserTranslator.ToDomainObjects(_UserRepository.GetAll_Internal());
            return result;
        }
       
        public List<UserJson> GetAllUserOuter()
        {
            var result = new List<UserJson>();
            UserRepository _UserRepository = new UserRepository();
            UserTranslator _UserTranslator = new UserTranslator();
            result = _UserTranslator.ToDomainObjects(_UserRepository.GetAll_Outer());
            return result;
        }
    }
}
