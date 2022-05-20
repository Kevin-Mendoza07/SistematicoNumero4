using Microsoft.EntityFrameworkCore;
using PepitoSchoolDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Domain.Interfaces
{
    public interface IPepitoSchoolDbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }

        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
