using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    /// <summary>
    /// 玩家状态
    /// </summary>
    public class Player : LivingEntity
    {
        private string _characterClass;
        private int _experiencePoints;

        /// <summary>
        /// 角色类型
        /// </summary>
        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 经验值
        /// </summary>
        public int ExperiencePoints
        {
            get => _experiencePoints;
           private set
            {
                _experiencePoints = value;
                OnPropertyChanged();
                SetLevelAndMaximumHitPoints();
            }
        }
        
        /// <summary>
        /// 任务状态集合
        /// </summary>
        public ObservableCollection<QuestStatus> Quests { get;}

        /// <summary>
        /// 用户升级事件
        /// </summary>
        public event EventHandler OnLeveledUp;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Player(string name, string characterClass, int experiencePoints,
            int maximumHitPoints, int currentHitPoints, int gold) :
            base(name, maximumHitPoints, currentHitPoints, gold)
        {
            CharacterClass = characterClass;
            ExperiencePoints = experiencePoints;

            Quests = new ObservableCollection<QuestStatus>();
        }

        /// <summary>
        /// 判断是否存在足够的物品
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if (Inventory.Count(i => i.ItemTypeId == item.ItemId) < item.Quantity)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 增加经验值
        /// </summary>
        /// <param name="experiencePoints"></param>
        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        /// <summary>
        /// 获取等级和最大生命值
        /// </summary>
        private void SetLevelAndMaximumHitPoints()
        {
            int originalLevel = Level;

            Level = (ExperiencePoints / 10) + 1;

            if (Level != originalLevel)
            {
                MaximumHitPoints = Level * 10;

                CompletelyHeal();

                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
    }
}
