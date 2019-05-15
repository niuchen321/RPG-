using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    /// <summary>
    /// 怪物类
    /// </summary>
    public class Monster : LivingEntity
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// 最小伤害
        /// </summary>
        public int MinimumDamage { get; set; }
        /// <summary>
        /// 最大伤害
        /// </summary>
        public int MaximumDamage { get; set; }


        /// <summary>
        /// 奖励经验值
        /// </summary>
        public int RewardExperiencePoints { get; private set; }

        public Monster(string name, string imageName,
            int maximumHitPoints, int hitPoints,
            int minimumDamage, int maxmumDamage,
            int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = $"/Engine;component/Images/Monsters/{imageName}";
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = hitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            Gold = rewardGold;
            MinimumDamage = minimumDamage;
            MaximumDamage = maxmumDamage;
        }
    }
}
