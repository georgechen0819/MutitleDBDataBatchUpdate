using MutitleDBDataBatchUpdate.Models.Entitis;
using MutitleDBDataBatchUpdate.Models.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutitleDBDataBatchUpdate
{
    class Application
    {
        private IBatchRepository _batchRepository;

        private int insertRecordQty = 100;

        public Application(IBatchRepository iBatchRepository)
        {
            _batchRepository = iBatchRepository;
        }

        public void Run()
        {
            AddBatchItemByNormalAdd(1 , insertRecordQty);
            AddBatchItemByBatchAdd(2, insertRecordQty); 
        }

        public void AddBatchItemByNormalAdd(int batchKey , int insertItemQty)
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            for (int i = 0; i < insertItemQty; i++)
            {
                _batchRepository.Add(new BatchIten()
                {
                    BatchKey = batchKey,
                    CreateTime = DateTime.Now,
                    Id = Guid.NewGuid().ToString()
                });
            }
            sw.Stop();
            Console.WriteLine($"AddBatchItemByNormalAdd  {sw.ElapsedMilliseconds}ms");
        }

        public void AddBatchItemByBatchAdd(int batchKey, int insertItemQty)
        {
            List<BatchIten> batchItems = new List<BatchIten>();
            for (int i = 0; i < insertItemQty; i++)
            {
                batchItems.Add(new BatchIten()
                {
                    BatchKey = batchKey,
                    CreateTime = DateTime.Now,
                    Id = Guid.NewGuid().ToString()
                });
            }
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            _batchRepository.BatchAdd(batchItems);
            sw.Stop();
            Console.WriteLine($"AddBatchItemByNormalAdd  {sw.ElapsedMilliseconds}ms");
        }
    }
}
