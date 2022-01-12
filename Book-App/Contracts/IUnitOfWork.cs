using Book_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Book> Books { get; }
        IRepositoryBase<Tags> Tags { get; }
        IRepositoryBase<TagAllocation> TagAllocations { get; }
        Task Save();
    }
}
