using MutitleDBDataBatchUpdate.Models.Entitis;
using System.Collections.Generic;
using System.Linq;

namespace MutitleDBDataBatchUpdate.Models.Repos
{
    public interface IBatchRepository
    {
        int Add(BatchIten item);
        int BatchAdd(List<BatchIten> items);
        void Dispose();
        IQueryable<BatchIten> GetBatchItens();
    }
}