using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 交易商店
    /// </summary>
   public class Trader: LivingEntity
    {
        public Trader(string name)
        {
            Name = name;
        }

    }
}
