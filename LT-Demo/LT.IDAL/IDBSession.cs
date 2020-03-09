using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.IDAL
{
    public interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();
    }
}
