using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CLLMettingManegmentNew.Entity;

namespace DBMettingManegmentNew
{
    public class AdminsRepository
    {
        private SEDbContext _context;

        public AdminsRepository()
        {
            _context = new SEDbContext();
        }

        //public List<EfAdmins> GetAll()
        //{
        //    return _context.EfAdmins.ToList();
        //}
        //public void Add(EfAdmins entity)
        //{
        //    _context.EfAdmins.Add(entity);
        //    _context.SaveChanges();
        //}
        //public void Delete(EfAdmins entity)
        //{
        //    _context.EfAdmins.Remove(entity);
        //    _context.SaveChanges();
        //}
        //public void Update(EfAdmins entity)
        //{
        //    var entityfind = _context.EfAdmins.Find(entity.ID);
        //    _context.SaveChanges();
        //}

    }
}
