using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Applications.Interfaces
{
    public interface IService<T>
    {
        void Create(T t);
        bool Delete(T t);
        int Update(T t);
        List<T> GetAll();
    }
}
