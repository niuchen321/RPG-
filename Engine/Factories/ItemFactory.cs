using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    /// <summary>
    /// 游戏项工厂
    /// </summary>
   public static class ItemFactory
    {
        /// <summary>
        /// 标准游戏项
        /// </summary>
        private static readonly List<GameItem> StandardGameItems=new List<GameItem>();

        static ItemFactory()
        {
            StandardGameItems.Add(new Weapon(1001, "尖棍", 1, 1, 2));
            StandardGameItems.Add(new Weapon(1002, "锈剑", 5, 1, 3));
            StandardGameItems.Add(new GameItem(9001, "蛇牙", 1));
            StandardGameItems.Add(new GameItem(9002, "蛇皮", 2));
            StandardGameItems.Add(new GameItem(9003, "鼠尾", 1));
            StandardGameItems.Add(new GameItem(9004, "老鼠的皮毛", 2));
            StandardGameItems.Add(new GameItem(9005, "蜘蛛毒牙", 1));
            StandardGameItems.Add(new GameItem(9006, "蜘蛛丝", 2));
        }

        /// <summary>
        /// 添加游戏项
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public static GameItem CreateGameItem(int itemTypeId)
        {
            GameItem standardItem = StandardGameItems.FirstOrDefault(item => item.ItemTypeId == itemTypeId);

            if (standardItem is Weapon)
            {
                return (standardItem as Weapon).Clone();
            }

            return standardItem?.Clone();
        }
    }
}
