﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using System.Linq;
using TE.BE.City.Infra.CrossCutting.Enum;

namespace TE.BE.City.Service.Services
{
    public class OcorrencyDetailService : IOcorrencyDetailService
    {
        private readonly IRepository<OcorrencyDetailEntity> _repository;

        public OcorrencyDetailService(IRepository<OcorrencyDetailEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OcorrencyDetailEntity>> GetAll(int skip, int limit)
        {
            var ocorrencyDetailEntity = new List<OcorrencyDetailEntity>();

            try
            {
                IEnumerable<OcorrencyDetailEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Select();
                else
                    result = await _repository.SelectWithPagination(skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new OcorrencyDetailEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    ocorrencyDetailEntity.Add(contactEntity);
                }

                return ocorrencyDetailEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<OcorrencyDetailEntity>> GetById(int id)
        {
            var ocorrencyDetailEntity = new List<OcorrencyDetailEntity>();

            try
            {
                var result = await _repository.SelectById(id);

                if (result != null)
                    ocorrencyDetailEntity.Add(result);
                else
                {
                    var contactEntity = new OcorrencyDetailEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    ocorrencyDetailEntity.Add(contactEntity);
                }

                return ocorrencyDetailEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<OcorrencyDetailEntity>> GetClosed(bool closed, int skip, int limit)
        {
            var ocorrencyDetailEntity = new List<OcorrencyDetailEntity>();

            try
            {
                IEnumerable<OcorrencyDetailEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Filter(c => c.Closed == closed);
                else
                    result = await _repository.FilterWithPagination(c => c.Closed == closed, skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new OcorrencyDetailEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    ocorrencyDetailEntity.Add(contactEntity);
                }

                return ocorrencyDetailEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }
    }
}
