using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
   internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World world = new World();

            return world;
        }
    }
}
