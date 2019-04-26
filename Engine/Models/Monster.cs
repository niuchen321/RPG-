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
    public class Monster : BaseNotificationClass
    {
        /// <summary>
        /// 血量
        /// </summary>
        private int _hitPoints;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 最大血量
        /// </summary>
        public int MaximumHitPoints { get; private set; }
        /// <summary>
        /// 血量
        /// </summary>
        public int HitPoints
        {
            get => _hitPoints;
            private set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        /// <summary>
        /// 奖励经验值
        /// </summary>
        public int RewardExperiencePoints { get; private set; }
        /// <summary>
        /// 奖励金币
        /// </summary>
        public int RewardGold { get; private set; }
        /// <summary>
        /// 物品项
        /// </summary>
        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName,
            int maximumHitPoints, int hitPoints,
            int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
