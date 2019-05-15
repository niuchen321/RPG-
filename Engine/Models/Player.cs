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
        private int _level;
        
        /// <summary>
        /// 角色类型
        /// </summary>
        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }

        /// <summary>
        /// 经验值
        /// </summary>
        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level
        {
            get => _level; set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        
        /// <summary>
        /// 任务状态集合
        /// </summary>
        public ObservableCollection<QuestStatus> Quests { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
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
                if (Inventory.Count(i => i.ItemTypeId == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
