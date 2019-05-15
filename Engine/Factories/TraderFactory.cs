using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    /// <summary>
    /// 交易工厂
    /// </summary>
   public static class TraderFactory
    {
        private static readonly List<Trader> Traders = new List<Trader>();

        static TraderFactory()
        {
            Trader susan = new Trader("苏珊");
            susan.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader farmerTed = new Trader("农夫泰德");
            farmerTed.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader peteTheHerbalist = new Trader("草药医生皮特");
            peteTheHerbalist.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            AddTraderToList(susan);
            AddTraderToList(farmerTed);
            AddTraderToList(peteTheHerbalist);
        }

        /// <summary>
        /// 根据名称获取商店
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Trader GetTraderByName(string name)
        {
            return Traders.FirstOrDefault(t => t.Name == name);
        }

        /// <summary>
        /// 添加商店
        /// </summary>
        /// <param name="trader"></param>
        private static void AddTraderToList(Trader trader)
        {
            if (Traders.Any(t => t.Name == trader.Name))
            {
                throw new ArgumentException($"已经有一个名为'{trader.Name}'的商店");
            }

            Traders.Add(trader);
        }

    }
}
