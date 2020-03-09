using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LT.IDAL;
using LT.Model;

namespace LT.DAL
{
    public class DBSession :IDBSession
    {
        public DbContext Db { get { return DBSessionFactory.CreateDbContext(); } }

        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
