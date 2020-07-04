using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMettingManegmentNew
{
   public class UnitOfWork
    {
        private SEDbContext _context;
        public UnitOfWork()
        {
            _context = new SEDbContext();
        }
    }
}
