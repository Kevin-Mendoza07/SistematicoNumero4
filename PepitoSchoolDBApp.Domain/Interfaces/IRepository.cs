using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T t);
        bool Delete(T t);
        int Update(T t);
        List<T> GetAll();
    }
}
