﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    interface IMenuItem
    {
        string Title { get; }
        string Path { get; }
        void PrintTitle();
        void Execute();
    }
}