using System;
using System.Collections.Generic;

namespace Test_Rogue
{
    interface Entity
    {
        Point position { get; set; }
        void Step();
    }
}
