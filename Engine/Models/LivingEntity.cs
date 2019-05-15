using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 生物基类
    /// </summary>
   public abstract class LivingEntity:BaseNotificationClass
    {
        private string _name;
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _gold;

        /// <summary>
        /// 名称
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
        /// 当前生命值
        /// </summary>
        public int CurrentHitPoints
        {
            get => _currentHitPoints;
            set
            {
                _currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }

        /// <summary>
        /// 最大生命值
        /// </summary>
        public int MaximumHitPoints
        {
            get => _maximumHitPoints;
            set
            {
                _maximumHitPoints = value;
                OnPropertyChanged(nameof(MaximumHitPoints));
            }
        }

        /// <summary>
        /// 金币
        /// </summary>
        public int Gold
        {
            get => _gold;
            set
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
        /// 武器集合
        /// </summary>
        public List<GameItem> Weapons =>
            Inventory.Where(i => i is Weapon).ToList();


        protected LivingEntity()
        {
            Inventory = new ObservableCollection<GameItem>();
        }

        /// <summary>
        /// 添加物品
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }

        /// <summary>
        /// 移除物品
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);

            OnPropertyChanged(nameof(Weapons));
        }
    }
}
