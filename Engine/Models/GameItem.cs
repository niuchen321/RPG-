using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 游戏物品项
    /// </summary>
   public class GameItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ItemTypeId { get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get;  }

        /// <summary>
        /// 是否唯一
        /// </summary>
        public bool IsUnique { get;}

        public GameItem(int itemTypeId, string name, int price, bool isUnique = false)
        {
            ItemTypeId = itemTypeId;
            Name = name;
            Price = price;
            IsUnique = isUnique;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public GameItem Clone()
        {
            return new GameItem(ItemTypeId, Name, Price,IsUnique);
        }
    }
}
