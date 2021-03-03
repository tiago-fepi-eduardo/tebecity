using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using System.Linq;

namespace TE.BE.City.Service.Services
{
    public class AboutService : IAboutService
    {
        private readonly IRepository<AboutEntity> _repository;

        public AboutService(IRepository<AboutEntity> repository)
        {
            _repository = repository;
        }

        public async Task<AboutEntity> Get()
        {
            try
            {
                var result = await _repository.Select();
                return result.FirstOrDefault();
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }
    }
}
