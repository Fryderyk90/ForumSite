﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Services
{
    public interface IProfanityFilter
    {
      //  Task<string> MicroString(string input);
        Task<string> Filter(string input);
    }
}
