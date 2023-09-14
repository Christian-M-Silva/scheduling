using Data.Context;
using Domain.Entites;
using Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PatientRepository : BaseRepository<PatientsEntity>, IPatientsRepository 
    {
        private DbSet<PatientsEntity> _dbSet;
        public PatientRepository(MyContext context) : base(context)
        {
            _dbSet = context.Set<PatientsEntity>();
        }

        public async Task<IEnumerable<PatientsEntity>> GetAllWithDate(DateTime date)
        {
            try
            {

                return await _dbSet.Where(patient => patient.ConsultationDate.Date == date.Date).ToListAsync();
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}
