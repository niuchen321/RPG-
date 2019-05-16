using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    /// <summary>
    /// 任务
    /// </summary>
    public class Quest
    {
        public int ID { get;}
        public string Name { get; }
        public string Description { get;}

        /// <summary>
        /// 完成项
        /// </summary>
        public List<ItemQuantity> ItemsToComplete { get;}
        /// <summary>
        /// 奖励经验值
        /// </summary>
        public int RewardExperiencePoints { get; }
        /// <summary>
        /// 奖励金币
        /// </summary>
        public int RewardGold { get; }
        /// <summary>
        /// 奖励项
        /// </summary>
        public List<ItemQuantity> RewardItems { get; }

        public Quest(int id, string name, string description, List<ItemQuantity> itemsToComplete,
            int rewardExperiencePoints, int rewardGold, List<ItemQuantity> rewardItems)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemsToComplete = itemsToComplete;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
        }
    }
}
