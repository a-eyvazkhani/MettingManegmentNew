using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System.Collections.Generic;

namespace CLLMettingManegmentNew.Translators
{
    public class AdminsTranslator
    {
       public JsonAdmins ToDomainObject(EfAdmins entity)
        {
            JsonAdmins admins = new JsonAdmins();
            admins.ID = entity.ID.ToString();
            admins.IDUser = entity.IDUser.ToString();
            admins.UserName = new UserTranslator().ToDomainObject(entity.UserID).UserName;
            return admins;
        }

        public List<JsonAdmins> ToDomainObject(List<EfAdmins> entities)
        {
            List<JsonAdmins> admin = new List<JsonAdmins>();

            foreach (var entity in entities)
                admin.Add(ToDomainObject(entity));

            return admin;
        }
        public EfAdmins Toentity(JsonAdmins domainObject)
        {
            var entity = new EfAdmins();
            Fillentity(entity, domainObject);
            return entity;
        }
        public void Fillentity(EfAdmins entity, JsonAdmins domainObject)
        {
            entity.ID = Guid.Parse(domainObject.ID);
            entity.IDUser = Guid.Parse(domainObject.IDUser);

        }


    }
}
