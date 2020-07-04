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
   public class MeetingUserRelBLL
    {
        public List<MeetingUserRelJson> GetUserGetByMeetingId(string MeetingId,string IsGetInFormed,string IsInternal)
        {
            var result = new List<MeetingUserRelJson>();
            var resultFainal = new List<MeetingUserRelJson>();

            MeetingUserRelRepository _MeetingUserRelRepository = new MeetingUserRelRepository();
            MeetingUserRelTranslator _MeetingUserRelTranslator = new MeetingUserRelTranslator();
            result = _MeetingUserRelTranslator.ToDomainObjects(_MeetingUserRelRepository.GetAll(Guid.Parse(MeetingId)));
            if (bool.Parse(IsGetInFormed))
            {
                foreach (MeetingUserRelJson metuserrel in result)
                {
                    if (bool.Parse(metuserrel.IsGetInFormed) == true)
                    {
                        resultFainal.Add(metuserrel);
                    }
                }
            }
            else if(bool.Parse(IsInternal))
            {
                foreach (MeetingUserRelJson metuserrel in result)
                {
                    if ((bool.Parse(metuserrel.IsInternal) == true)&&(bool.Parse(metuserrel.IsGetInFormed)==false))
                    {
                        resultFainal.Add(metuserrel);
                    }
                }
            }
            else if (!bool.Parse(IsInternal))
            {
                foreach (MeetingUserRelJson metuserrel in result)
                {
                    if (bool.Parse(metuserrel.IsInternal) == false)
                    {
                        
                       
                        resultFainal.Add(metuserrel);
                    }
                }
            }
            //foreach (MeetingUserRelJson userRel in resultFainal)
            //{
            //    PhoneNumbersRepository PhoneNumbersRepository = new PhoneNumbersRepository();
            //    userRel.Number = new PhoneNumberTraslator().ToDomainObject(PhoneNumbersRepository.GetByUserId(Guid.Parse(userRel.UserId))).Number ;
            //}
            return resultFainal;
        }



        public List<MeetingUserRelJson> GetAllUserUseMettingInternal(string MeetingId, string IsGetInFormed)
        {
            var result = new List<MeetingUserRelJson>();
            var resultFainal = new List<MeetingUserRelJson>();

            MeetingUserRelRepository _MeetingUserRelRepository = new MeetingUserRelRepository();
            MeetingUserRelTranslator _MeetingUserRelTranslator = new MeetingUserRelTranslator();
            result = _MeetingUserRelTranslator.ToDomainObjects(_MeetingUserRelRepository.GetAll(Guid.Parse(MeetingId)));
            if (!bool.Parse(IsGetInFormed))
            {
                foreach (MeetingUserRelJson metuserrel in result)
                {
                    if (bool.Parse(metuserrel.IsGetInFormed) == false)
                    {
                        resultFainal.Add(metuserrel);
                    }
                }
            }
           
           
            return resultFainal;
        }


        public List<MeetingUserRelJson> GetAllUserUseMettingNotInternal(string MeetingId, string IsGetInFormed)
        {
            var result = new List<MeetingUserRelJson>();
            var resultFainal = new List<MeetingUserRelJson>();

            MeetingUserRelRepository _MeetingUserRelRepository = new MeetingUserRelRepository();
            MeetingUserRelTranslator _MeetingUserRelTranslator = new MeetingUserRelTranslator();
            result = _MeetingUserRelTranslator.ToDomainObjects(_MeetingUserRelRepository.GetAll(Guid.Parse(MeetingId)));
            if (bool.Parse(IsGetInFormed))
            {
                foreach (MeetingUserRelJson metuserrel in result)
                {
                    if (bool.Parse(metuserrel.IsGetInFormed) == true)
                    {
                        resultFainal.Add(metuserrel);
                    }
                }
            }


            return resultFainal;
        }
    }
}
