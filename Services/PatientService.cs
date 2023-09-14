using Domain.Entites;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PatientService : IPatientService
    {
        private IPatientsRepository _repository;

        public PatientService(IPatientsRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public Task<PatientsEntity> Get(Guid id)
        {
            return _repository.Get(id);
        }

        public Task<IEnumerable<PatientsEntity>> GetAllWithDate(DateTime date)
        {
            return _repository.GetAllWithDate(date);
        }

        public async Task<bool> HasVacanancy(DateTime date)
        {
            if (date < DateTime.Now)
            {
                throw new ArgumentException("O sistema encontrou algum erro com a data da consulta, verifique se ela não é uma data menor que a atual");
            }
            var vacanancy = await _repository.GetAllWithDate(date);
            return vacanancy.Count() < 5;
        }

        public async Task<PatientsEntity> Post(PatientsEntity entity)
        {
            var hasVacanancy = await this.HasVacanancy(entity.ConsultationDate);
            if (hasVacanancy)
            {
            return await _repository.Post(entity);

            }
            throw new ArgumentException("Não há vagas disponíveis para esse dia.");

        }

        public async Task<PatientsEntity> Update(PatientsEntity entity, Guid id)
        {
            var hasVacanancy = await this.HasVacanancy(entity.ConsultationDate);
            if (hasVacanancy)
            {
                return await _repository.Update(entity, id);

            }
            throw new ArgumentException("Não há vagas disponíveis para esse dia.");
        }
    }
}
