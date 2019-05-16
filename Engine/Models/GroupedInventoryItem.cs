using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 库存物品分组
    /// </summary>
   public class GroupedInventoryItem:BaseNotificationClass
    {
        private GameItem _item;
        private int _quantity;

        /// <summary>
        /// 游戏物品项
        /// </summary>
        public GameItem Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public GroupedInventoryItem(GameItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
