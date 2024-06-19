using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Orleans.Runtime;

namespace TestExtensions
{
    // used for test constants
    internal static class TestConstants
    {
        public static readonly Random random = Random.Shared;

        public static readonly TimeSpan InitTimeout =
            Debugger.IsAttached ? TimeSpan.FromMinutes(10) : TimeSpan.FromMinutes(1);
        
    }
}
