using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.ProcessHandlers
{
    internal class DelayTimers
    {
        public void WaitFooSeconds( int seconds )
        {
            int multiplier = seconds * 1000;
            Task.Delay(multiplier);
        }
    }
}
