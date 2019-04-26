using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 游戏项
    /// </summary>
   public class GameItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        public GameItem(int itemTypeId, string name, int price)
        {
            ItemTypeId = itemTypeId;
            Name = name;
            Price = price;
        }


        public GameItem Clone()
        {
            return new GameItem(ItemTypeId, Name, Price);
        }
    }
}
