using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutitleDBDataBatchUpdate.Models.Entitis
{
    public class TestDbConnection : ITestDbConnection
    {
        private TestDBEntities _db;

        public TestDbConnection()
        {
            _db = new TestDBEntities();
        }

        public IQueryable<BatchIten> QueryableBatchItem => _db.BatchIten;

        public void Modified<T>(T model, EntityState state) where T : class
        {
            var entry = _db.Entry<T>(model);

            entry.State = state;

        }

        public int SaveChange()
        {
            return _db.SaveChanges();
        }
        public void Dispose(bool isReNewDbConn)
        {
            _db.Dispose();

            if (isReNewDbConn)
            {
                ReNewDbConn();
            }
        }

        // 錯誤示範，這裡違反了 DI/IOC 原則
        public void ReNewDbConn()
        {
            _db = new TestDBEntities();
        }
    }
}
