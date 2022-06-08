﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IAsphaltService
    {
        Task<AsphaltEntity> Post(AsphaltEntity request);
        Task<AsphaltEntity> Put(AsphaltEntity request);
        Task<AsphaltEntity> Delete(int id);
        Task<IEnumerable<AsphaltEntity>> GetAll(bool closed, int skip, int limit);
        Task<IEnumerable<AsphaltEntity>> GetById(int id);
        Task<int> GetCount(bool closed);
        Task<IEnumerable<AsphaltEntity>> GetByOcorrencyId(bool closed, int ocorrencyId);
    }
}
