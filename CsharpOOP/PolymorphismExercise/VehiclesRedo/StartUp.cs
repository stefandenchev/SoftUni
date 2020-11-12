using System;
using VehiclesRedo.Core;

namespace VehiclesRedo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
