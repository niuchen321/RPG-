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

        private int _level;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get => _name;
           private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前生命值
        /// </summary>
        public int CurrentHitPoints
        {
            get => _currentHitPoints;
           private set
            {
                _currentHitPoints = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 最大生命值
        /// </summary>
        public int MaximumHitPoints
        {
            get => _maximumHitPoints;
           protected set
            {
                _maximumHitPoints = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 金币
        /// </summary>
        public int Gold
        {
            get => _gold;
           private set
            {
                _gold = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level
        {
            get => _level;
            protected set
            {
                _level = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 游戏物品项集合
        /// </summary>
        public ObservableCollection<GameItem> Inventory { get; }

        /// <summary>
        /// 物品分组集合
        /// </summary>
        public ObservableCollection<GroupedInventoryItem> GroupedInventory { get;  }

        /// <summary>
        /// 武器集合
        /// </summary>
        public List<GameItem> Weapons =>
            Inventory.Where(i => i is Weapon).ToList();

        /// <summary>
        /// 是否死亡
        /// </summary>
        public bool IsDead => CurrentHitPoints <= 0;

        /// <summary>
        /// 死亡事件
        /// </summary>
        public event EventHandler OnKilled;

        protected LivingEntity(string name, int maximumHitPoints, int currentHitPoints, int gold, int level = 1)
        {
            Name = name;
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
            Gold = gold;
            Level = level;

            Inventory = new ObservableCollection<GameItem>();
            GroupedInventory = new ObservableCollection<GroupedInventoryItem>();
        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="hitPointsOfDamage">受到的伤害</param>
        public void TakeDamage(int hitPointsOfDamage)
        {
            CurrentHitPoints -= hitPointsOfDamage;

            if (IsDead)
            {
                CurrentHitPoints = 0;
                RaiseOnKilledEvent();
            }
        }

        /// <summary>
        /// 治愈
        /// </summary>
        /// <param name="hitPointsToHeal">增加血量</param>
        public void Heal(int hitPointsToHeal)
        {
            CurrentHitPoints += hitPointsToHeal;

            if (CurrentHitPoints > MaximumHitPoints)
            {
                CurrentHitPoints = MaximumHitPoints;
            }
        }

        /// <summary>
        /// 完全治愈
        /// </summary>
        public void CompletelyHeal()
        {
            CurrentHitPoints = MaximumHitPoints;
        }

        /// <summary>
        /// 收到金币
        /// </summary>
        /// <param name="amountOfGold">金币数量</param>
        public void ReceiveGold(int amountOfGold)
        {
            Gold += amountOfGold;
        }

        /// <summary>
        /// 付出金币
        /// </summary>
        /// <param name="amountOfGold">金币数量</param>
        public void SpendGold(int amountOfGold)
        {
            if (amountOfGold > Gold)
            {
                throw new ArgumentOutOfRangeException($"{Name} 只有 {Gold} 金币, 不能支付 {amountOfGold} 金币");
            }

            Gold -= amountOfGold;
        }

        /// <summary>
        /// 添加物品
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            if (item.IsUnique)
            {
                GroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            else
            {
                if (GroupedInventory.All(gi => gi.Item.ItemTypeId != item.ItemTypeId))
                {
                    GroupedInventory.Add(new GroupedInventoryItem(item, 0));
                }

                GroupedInventory.First(gi => gi.Item.ItemTypeId == item.ItemTypeId).Quantity++;
            }

            OnPropertyChanged(nameof(Weapons));
        }

        /// <summary>
        /// 移除物品
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);
            GroupedInventoryItem groupedInventoryItemToRemove =item.IsUnique?
                GroupedInventory.FirstOrDefault(gi => gi.Item == item):GroupedInventory.FirstOrDefault(gi=>gi.Item.ItemTypeId==item.ItemTypeId);

            if (groupedInventoryItemToRemove != null)
            {
                if (groupedInventoryItemToRemove.Quantity == 1)
                {
                    GroupedInventory.Remove(groupedInventoryItemToRemove);
                }
                else
                {
                    groupedInventoryItemToRemove.Quantity--;
                }
            }
            OnPropertyChanged(nameof(Weapons));
        }

        #region 私有方法

        /// <summary>
        /// 调用OnKilled事件
        /// </summary>
        private void RaiseOnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }

        #endregion
    }
}
