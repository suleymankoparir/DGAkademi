﻿using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Services
{
    public interface IPerformerService : IService<Performer>
    {
        public Task<List<PerformerGetAllDto>> getAllData();
        public Task<PerformerGetAllDto> GetAllWithDataById(int id);
    }
}