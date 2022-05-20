using PepitoSchoolDBApp.Applications.Interfaces;
using PepitoSchoolDBApp.Domain.Entities;
using PepitoSchoolDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Applications.Services
{
    public class EstudianteService : IEstudianteService
    {
        public IEstudianteRepository estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }
        public decimal CalculoPromedio(Estudiante Notas)
        {
            return estudianteRepository.CalculoPromedio(Notas);
        }

        public void Create(Estudiante t)
        {
           estudianteRepository.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            return estudianteRepository.Delete(t);
        }

        public Estudiante FindById(int id)
        {
            return estudianteRepository.FindById(id);
        }

        public List<Estudiante> GetAll()
        {
            return estudianteRepository.GetAll();
        }

        public int Update(Estudiante t)
        {
            return estudianteRepository.Update(t);
        }
    }
}
