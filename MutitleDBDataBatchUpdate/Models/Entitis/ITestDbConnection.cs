using System;
using System.Data.Entity;
using System.Linq;

namespace MutitleDBDataBatchUpdate.Models.Entitis
{
    public interface ITestDbConnection: IDisposable
    {
        IQueryable<BatchIten> QueryableBatchItem { get; }
        void Modified<T>(T model, EntityState state) where T : class;
        int SaveChange();
    }
}