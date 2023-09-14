using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IPatientsRepository: IBaseRepository<PatientsEntity>
    {
        Task<IEnumerable<PatientsEntity>> GetAllWithDate(DateTime date);

    }
}
