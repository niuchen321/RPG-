using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
   public class World
   {
       private List<Location> _locations = new List<Location>();

       internal void AddLocation(Location location)
       {
           _locations.Add(location);
       }
   }
}
