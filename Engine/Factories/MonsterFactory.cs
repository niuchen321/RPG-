using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    /// <summary>
    /// 怪物仓库
    /// </summary>
    public static class MonsterFactory
    {
        /// <summary>
        /// 根据ID获取怪物
        /// </summary>
        /// <param name="monsterID"></param>
        /// <returns></returns>
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster snake =
                        new Monster("蛇", "Snake.png", 4, 4,1,2, 5, 1);

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;

                case 2:
                    Monster rat =
                        new Monster("老鼠", "Rat.png", 5, 5,1,2, 5, 1);

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);

                    return rat;

                case 3:
                    Monster giantSpider =
                        new Monster("巨型蜘蛛", "GiantSpider.png", 10, 10,1,4, 10, 3);

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 75);

                    return giantSpider;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }

       /// <summary>
       /// 添加战利品
       /// </summary>
       /// <param name="monster">怪物</param>
       /// <param name="itemId">物品ID</param>
       /// <param name="percentage">出现概率</param>
        private static void AddLootItem(Monster monster, int itemId, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.Inventory.Add(ItemFactory.CreateGameItem(itemId));
            }
        }
    }
}
