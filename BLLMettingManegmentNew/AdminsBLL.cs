using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using CLLMettingManegmentNew.Translators;
using DBMettingManegmentNew;


namespace BLLMettingManegmentNew
{
    public class AdminsBLL
    {
        public List<JsonAdmins> GetAll()
        {
            var result = new List<JsonAdmins>();
            AdminsRepository _AdminRepository = new AdminsRepository();
            AdminsTranslator _AdminTranlator = new AdminsTranslator();
          //  result = _AdminTranlator.ToDomainObject(_AdminRepository.GetAll());
            return result;
        }
        public string AddAdmin(JsonAdmins _Admins)
        {
            var result = string.Empty;
            AdminsRepository _AdminRepository = new AdminsRepository();
            AdminsTranslator _AdminTranslator = new AdminsTranslator();
            if (_Admins.ID == "")
            {
                _Admins.ID = Guid.NewGuid().ToString();
                //_AdminRepository.Add(_AdminTranslator.Toentity(_Admins));
            }
            return result;
        }
    }
}
