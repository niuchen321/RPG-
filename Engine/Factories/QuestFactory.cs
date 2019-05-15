using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        /// <summary>
        /// 任务集合
        /// </summary>
        private static readonly List<Quest> Quests = new List<Quest>();

        static QuestFactory()
        {
            // 声明需要完成任务的物品及其奖励物品
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            itemsToComplete.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));

            // 创建任务
            Quests.Add(new Quest(1,
                "清理药草花园",
                "在草药师的花园里打败蛇",
                itemsToComplete,
                25, 10,
                rewardItems));
        }

        /// <summary>
        /// 根据ID获取任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static Quest GetQuestById(int id)
        {
            return Quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
