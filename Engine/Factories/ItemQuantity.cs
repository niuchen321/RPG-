using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    /// <summary>
    /// 物品项
    /// </summary>
   public class ItemQuantity
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId { get; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; }

        public ItemQuantity(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
