using Autofac.Util;
using MutitleDBDataBatchUpdate.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutitleDBDataBatchUpdate.Models.Repos
{
    public class BatchRepository : IBatchRepository
    {
        private ITestDbConnection _testDbConnection;

        public BatchRepository(ITestDbConnection iTestDbConnection)
        {
            _testDbConnection = iTestDbConnection;
        }

        public IQueryable<BatchIten> GetBatchItens()
        {
            return _testDbConnection.QueryableBatchItem;
        }

        public int Add(BatchIten item)
        {
            _testDbConnection.Modified(item, EntityState.Added);

            return _testDbConnection.SaveChange();
        }

        public int BatchAdd(List<BatchIten> items)
        {
            int addRecrod = 0;
            int batchCount = 20;
            for (int i = 0; i < (items.Count() / batchCount); i++)
            {
                foreach (var item in items.Skip(i * batchCount).Take(batchCount))
                {
                    _testDbConnection.Modified(item, EntityState.Added);
                }

                addRecrod += _testDbConnection.SaveChange();
                _testDbConnection.Dispose();
            }

            return addRecrod;
        }
    }
}
