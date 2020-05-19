using System.Data.Entity;
using System.Linq;

namespace MutitleDBDataBatchUpdate.Models.Entitis
{
    public interface ITestDbConnection
    {
        IQueryable<BatchIten> QueryableBatchItem { get; }

        void Dispose(bool isReNewDbConn);
        void Modified<T>(T model, EntityState state) where T : class;
        void ReNewDbConn();
        int SaveChange();
    }
}