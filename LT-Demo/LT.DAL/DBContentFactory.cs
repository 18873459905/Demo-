using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LT.Model;
namespace LT.DAL
{
    public class DBSessionFactory {
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new LTDBContent();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }

}
