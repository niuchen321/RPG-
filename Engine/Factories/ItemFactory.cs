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
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "尖棍", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "锈剑", 5, 1, 3));
            _standardGameItems.Add(new GameItem(9001, "蛇牙", 1));
            _standardGameItems.Add(new GameItem(9002, "蛇皮", 2));
            _standardGameItems.Add(new GameItem(9003, "鼠尾", 1));
            _standardGameItems.Add(new GameItem(9004, "老鼠的皮毛", 2));
            _standardGameItems.Add(new GameItem(9005, "蜘蛛毒牙", 1));
            _standardGameItems.Add(new GameItem(9006, "蜘蛛丝", 2));
        }

        public static GameItem CreateGameItem(int itemTypeId)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeId == itemTypeId);

            return standardItem?.Clone();
        }
    }
}
