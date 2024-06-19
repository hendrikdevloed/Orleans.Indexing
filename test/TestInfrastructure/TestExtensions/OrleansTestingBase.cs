using System;
using Orleans.Runtime;

namespace TestExtensions
{
    public abstract class OrleansTestingBase
    {
        public static long GetRandomGrainId()
        {
            return Random.Shared.Next();
        }
    }
}