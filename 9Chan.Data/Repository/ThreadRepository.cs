﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public class ThreadRepository : IThreadRepository
    {
        public Task<Thread> GetThreadInSubCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
