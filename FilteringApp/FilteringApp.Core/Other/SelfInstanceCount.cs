using System;
using System.Collections.Generic;
using System.Text;

namespace FilteringApp.Core.Other
{
    public class SelfInstanceCount
    {
        public static int activeCount = 0;

        public SelfInstanceCount()
        {
            activeCount++;
            Console.WriteLine("Instance created");
        }

         ~SelfInstanceCount()
        {
            activeCount--;
            Console.WriteLine("Instance destroyed");
        }
    }
}
