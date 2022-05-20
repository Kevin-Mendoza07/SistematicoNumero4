using PepitoSchoolDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Applications.Interfaces
{
    public interface IEstudianteService:IService<Estudiante>
    {
        decimal CalculoPromedio(Estudiante Notas);
        Estudiante FindById(int id);
    }
}
