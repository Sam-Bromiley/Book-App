using Book_App.Contracts;
using Book_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepositoryBase<Book> _books;
        private IRepositoryBase<Tags> _tags;
        private IRepositoryBase<TagAllocation> _tagAllocations;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IRepositoryBase<Book> Books => _books ??=  new RepositoryBase<Book>(_context);
        //public IRepositoryBase<Book> Books 
        //get => _books == null ? _books : new RepositoryBase<Book>(_context); line above same as this

        public IRepositoryBase<Tags> Tags => _tags ??= new RepositoryBase<Tags>(_context);
        public IRepositoryBase<TagAllocation> TagAllocations => _tagAllocations ??= new RepositoryBase<TagAllocation>(_context);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if(dispose)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
