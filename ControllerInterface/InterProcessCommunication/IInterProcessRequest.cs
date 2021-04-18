﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInterface.InterProcessCommunication
{
    public interface IInterProcessRequest
    {
        bool RequireSucess { get; }
        bool Execute();
    }
}
