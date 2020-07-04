using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
  public  class UnitTranslator
    {
        public UnitJson ToDomainObject(EfUnit entity)
        {
           

            UnitJson _UnitJson = new UnitJson();
            _UnitJson.Title = entity.Title;
            _UnitJson.ID = entity.ID.ToString();
            _UnitJson.AccessGroups = entity.AccessGroups;
            return _UnitJson;
        }

        public List<UnitJson> ToDomainObjects(IEnumerable<EfUnit> entities)
        {
            List<UnitJson> Unit = new List<UnitJson>();
            foreach (var entity in entities)
                Unit.Add(ToDomainObject(entity));
            return Unit;
        }

    }
}
