using CLLMettingManegmentNew.Entity;
using CLLMettingManegmentNew.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLLMettingManegmentNew.Translators
{
   public class UserTranslator
    {

        public UserJson ToDomainObject(EfUser entity)
        {
            UserJson user = new UserJson();

            user.ID = entity.ID.ToString();

            //if (entity.CompanyId.HasValue)
            //    user.Company = new CompanyTranslator().ToDomainObject(entity.Company);
            user.Department = entity.Department;

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Isinternal = entity.IsInternal;
            user.FullName = entity.FirstName + " " + entity.LastName;
            //user.JobTitle = entity.JobTitle;
            //if (entity.IsInternal)
            //    user.SetFullQualifyName(entity.FullQualifyName);

            user.UserName = entity.UserName;
            //user.Email = new EmailTranslator().ToDomainObject(entity.Email).EmailAddress;
            //user.Mobile = new PhoneNumberTraslator().ToDomainObject(entity.PhoneNumber).Number;
            //user.ti = entity.Title;
            //user.NationalCode = entity.NationalCode;
            if (entity.Mobiles != null)
            {
                foreach (var _Mobiles in entity.Mobiles)
                    user.PhoneNumberJson = (new PhoneNumberTraslator().ToDomainObject(_Mobiles));
                user.Mobile = user.PhoneNumberJson.Number;

            }
            //else
            //{

            //    foreach (var mbiles in entity.Mobiles)
            //        user.AddPhoneNumber(new PhoneNumberTraslator().ToDomainObject(mbiles));

            //}
            if (entity.Emails != null)
            {
                foreach (var _Emails in entity.Emails)
                    user.EmailJson = (new EmailTranslator().ToDomainObject(_Emails));
                user.Email = user.EmailJson.EmailAddress;

            }
            //else
            //{

            //    foreach (var emails in entity.Emails)
            //        user.AddEmails(new EmailTranslator().ToDomainObject(emails));
            //}

            //if (entity.Addresses == null)
            //{
            //    var address = new EfAddress();
            //    user.AddAddress(new AddressTranslator().ToDomainObject(address));

            //}
            //else
            //{

            //    foreach (var address in entity.Addresses)
            //        user.AddAddress(new AddressTranslator().ToDomainObject(address));
            //}
            return user;
        }


        public List<UserJson> ToDomainObjects(IEnumerable<EfUser> entities)
        {

            List<UserJson> meetings = new List<UserJson>();

            foreach (var entity in entities)
                meetings.Add(ToDomainObject(entity));

            return meetings;
        }

        public EfUser Toentity(UserJson Domainobj)
        {
            var entity = new EfUser();
            fillentity(entity, Domainobj);
            return entity;
        }
        public void fillentity(EfUser entity,UserJson domainobj)
        {
            entity.ID = Guid.Parse(domainobj.ID);
            entity.FirstName = domainobj.FirstName;
            entity.LastName = domainobj.LastName;            
            entity.UserName = domainobj.FirstName + domainobj.LastName;
            entity.FullQualifyName = domainobj.FirstName + domainobj.LastName;
            entity.Department = domainobj.Department;
            entity.IsInternal = domainobj.Isinternal;
            entity.IsDeleted = domainobj.IsDeleted;
            entity.CompanyId = Guid.Parse(domainobj.CompanyId);
            entity.JobTitle = domainobj.JobTitle;
            entity.NationalCode = domainobj.Nationalcode;
            entity.Title = domainobj.Title;

        }
    }
}
