using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IPatientService
    {
        Task<PatientsEntity> Get(Guid id);
        Task<PatientsEntity> Post(PatientsEntity entity);
        Task<PatientsEntity> Update(PatientsEntity entity, Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<PatientsEntity>> GetAllWithDate(DateTime date);
        Task<bool> HasVacanancy(DateTime date);
        Task<IEnumerable<PatientsEntity>> GetAll();
    }
}
