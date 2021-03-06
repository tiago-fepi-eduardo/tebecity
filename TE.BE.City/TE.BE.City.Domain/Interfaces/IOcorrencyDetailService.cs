﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IOcorrencyDetailService
    {
        Task<IEnumerable<OcorrencyDetailEntity>> GetAll(bool closed, int skip, int limit);
        Task<IEnumerable<OcorrencyDetailEntity>> GetById(int id);
        Task<int> GetCount(bool closed);
        Task<IEnumerable<OcorrencyDetailEntity>> GetByOcorrencyId(bool closed, int ocorrencyId);
    }
}
