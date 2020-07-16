using GreenVsRed.Core;
using System;

namespace GreenVsRed
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Instantiate the Engine class.
            Engine engine = new Engine();

            //Execute the logic implemented in the Run method.
            engine.Run();
        }
    }
}
