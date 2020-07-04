using CLLMettingManegmentNew.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
   public class TaskRepository
    {
        private SEDbContext _context;
        public TaskRepository()
        {
            _context = new SEDbContext();
        }
        public List<EfTask> GetAllTaskByMettingId(Guid Id)
        {
            return _context.EfTask.Where(x => x.MeetingId == Id).ToList();
            //return new MeetingPlaceTranslator().ToDomainObjects(entities);
        }
        public void Add(EfTask entity)
        {

            _context.EfTask.Add(entity);
            _context.SaveChanges();
        }
        public void ChekhDelitByID(object id)
        {
            var entity = _context.EfTask.FirstOrDefault(x => x.ID == (Guid)id);
            if (entity != null)
                DeleteByID(entity);


        }
        public void DeleteByID(EfTask _eftask)
        {
            _context.EfTask.Remove(_eftask);
            _context.SaveChanges();

        }

    }
}
