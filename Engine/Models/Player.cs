using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 玩家状态
    /// </summary>
    public class Player : BaseNotificationClass
    {
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

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
        /// 生命值
        /// </summary>
        public int HitPoints
        {
            get => _hitPoints;
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
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
        /// 金币
        /// </summary>
        public int Gold
        {
            get => _gold; set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        /// <summary>
        /// 游戏项集合
        /// </summary>
        public ObservableCollection<GameItem> Inventory { get; set; }

        /// <summary>
        /// 任务状态集合
        /// </summary>
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }
    }
}
