﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folkmancer.OOP.ControlOfEducationalProcess
{
    class TestException : Exception
    {
        public TestException(string message)
                : base(message)
        {

        }
    }
}
