using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
      public interface IRepo<T,ID,RET>
    {
        // Create
        RET Create(T obj);

        // Read
        List<T> GetAll();
        T GetById(ID id);

        // Update
        RET Update(T obj);

        // Delete
        bool Delete(ID id);
    }
}
