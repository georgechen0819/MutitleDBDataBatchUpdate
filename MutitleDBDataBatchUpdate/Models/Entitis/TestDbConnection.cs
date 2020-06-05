using Autofac;
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
        private bool _disposed;
        private TestDBEntities _db;

        public TestDbConnection(TestDBEntities testDBEntities)
        {
            _db = testDBEntities;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            ReNewConnection();
        }

        private void ReNewConnection()
        {
            // 重新建立實體物件
            _db = Program.container.Resolve<TestDBEntities>();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
