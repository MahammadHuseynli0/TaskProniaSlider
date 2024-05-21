﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Core.Models;
using TaskProniaCrud.Core.RepositoryAbstarcts;
using TaskProniaCrud.Data.DAL;

namespace TaskProniaCrud.Data.RepositoryConcretes
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
