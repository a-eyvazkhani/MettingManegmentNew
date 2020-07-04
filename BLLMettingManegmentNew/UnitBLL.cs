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
   public class UnitBLL
    {
        public List<UnitJson> GetAllUnit()
        {
            var result = new List<UnitJson>();
            UnitRepository _UnitRepository = new UnitRepository();
            UnitTranslator _UnitTranslator = new UnitTranslator();
            result = _UnitTranslator.ToDomainObjects(_UnitRepository.GetAll());
            return result;
        }
    }
}
