using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// 完成项
        /// </summary>
        public List<ItemQuantity> ItemsToComplete { get; set; }
        /// <summary>
        /// 奖励经验值
        /// </summary>
        public int RewardExperiencePoints { get; set; }
        /// <summary>
        /// 奖励金币
        /// </summary>
        public int RewardGold { get; set; }
        /// <summary>
        /// 奖励项
        /// </summary>
        public List<ItemQuantity> RewardItems { get; set; }

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
