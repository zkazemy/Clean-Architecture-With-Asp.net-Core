using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface ICrudRepository<T,K>
    {
        ICollection<T> GetAll();
        void Add(T item);
        void Remove(K id);
    }
}
