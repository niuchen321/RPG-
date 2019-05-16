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
        public string ImageName { get; }

        /// <summary>
        /// 最小伤害
        /// </summary>
        public int MinimumDamage { get; }
        /// <summary>
        /// 最大伤害
        /// </summary>
        public int MaximumDamage { get; }


        /// <summary>
        /// 奖励经验值
        /// </summary>
        public int RewardExperiencePoints { get;}

        public Monster(string name, string imageName,
            int maximumHitPoints, int currentHitPoints,
            int minimumDamage, int maxmumDamage,
            int rewardExperiencePoints, int gold) :
            base(name, maximumHitPoints, currentHitPoints, gold)
        {
            ImageName = $"/Engine;component/Images/Monsters/{imageName}";
            MinimumDamage = minimumDamage;
            MaximumDamage = maxmumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
