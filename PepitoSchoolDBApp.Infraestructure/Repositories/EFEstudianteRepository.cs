using PepitoSchoolDBApp.Domain.Entities;
using PepitoSchoolDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Infraestructure.Repositories
{
    public class EFEstudianteRepository : IEstudianteRepository
    {

        public IPepitoSchoolDbContext pepitoSchoolDbContext;
        public EFEstudianteRepository(IPepitoSchoolDbContext pepitoSchoolDbContext)
        {
            this.pepitoSchoolDbContext = pepitoSchoolDbContext;
        }

        public decimal CalculoPromedio(Estudiante Notas)
        {
            decimal NotaFinal = Notas.Contabilidad + Notas.Programacion + Notas.Matematica + Notas.Estadistica;
            return NotaFinal / 4;
        
        }

       
        public void Create(Estudiante t)
        {
            if (t is null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            pepitoSchoolDbContext.Estudiantes.Add(t);
            pepitoSchoolDbContext.SaveChanges();
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Estudiante no puede ser null.");
                }

                Estudiante estudiante = FindById(t.Id);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto con id {t.Id} no existe.");
                }

                pepitoSchoolDbContext.Estudiantes.Remove(estudiante);
                int result = pepitoSchoolDbContext.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindById(int id)
        {
            return pepitoSchoolDbContext.Estudiantes.FirstOrDefault(x => x.Id == id);
        }

        public List<Estudiante> GetAll()
        {
            return pepitoSchoolDbContext.Estudiantes.ToList();
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto estudiante no puede ser null.");
                }

                Estudiante estudiante = FindById(t.Id);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto estudiante con id {t.Id} no existe.");
                }

                estudiante.Nombres = t.Nombres;
                estudiante.Apellidos = t.Apellidos;
                estudiante.Carnet= t.Carnet;
                estudiante.Phone = t.Phone;
                estudiante.Direccion=t.Direccion;
                estudiante.Correo = t.Correo;
                estudiante.Estadistica=t.Estadistica;
                estudiante.Contabilidad=t.Contabilidad;
                estudiante.Matematica=t.Matematica;
                estudiante.Programacion = t.Programacion;
                 

                pepitoSchoolDbContext.Estudiantes.Update(estudiante);
                return pepitoSchoolDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
