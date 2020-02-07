using System;
using System.Collections.Generic;
using System.Text;

namespace Rest.DataLayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Add(T data);

        void Update(T data);

        void Delete(T data);        
    }
}
