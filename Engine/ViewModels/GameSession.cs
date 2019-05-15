using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    /// <summary>
    /// 游戏动作
    /// </summary>
    public class GameSession : BaseNotificationClass
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        /// <summary>
        /// 当前状态
        /// </summary>
        public Player CurrentPlayer { get; set; }
        
        //当前位置
        private Location _currentLocation;
        //当前怪物
        private Monster _currentMonster;

        //当前商店
        private Trader _currentTrader;

        /// <summary>
        /// 当前位置信息
        /// </summary>
        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation));

                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));

                CompleteQuestsAtLocation();
                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();


                CurrentTrader = CurrentLocation.TraderHere;
            }
        }

        /// <summary>
        /// 当前怪物
        /// </summary>
        public Monster CurrentMonster
        {
            get => _currentMonster;
            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"你在这里发现了 {CurrentMonster.Name} ！");
                }
            }
        }

        /// <summary>
        /// 当前商店
        /// </summary>
        public Trader CurrentTrader
        {
            get => _currentTrader;
            set
            {
                _currentTrader = value;

                OnPropertyChanged(nameof(CurrentTrader));
                OnPropertyChanged(nameof(HasTrader));
            }
        }

        /// <summary>
        /// 判断当前是否存在商店
        /// </summary>
        public bool HasTrader => CurrentTrader != null;

        /// <summary>
        /// 当前世界
        /// </summary>
        public World CurrentWorld { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player()
            {
                Name = "晨",
                Gold = 10000,
                CharacterClass = "战士",
                ExperiencePoints = 0,
                CurrentHitPoints = 10,
                Level = 1
            };

            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
        }

        public Weapon CurrentWeapon { get; set; }

        //向北是否有位置
        public bool HasLocationToNorth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate,
                                              CurrentLocation.YCoordinate + 1) != null;

        //向东是否有位置
        public bool HasLocationToEast => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
        //向南是否有位置
        public bool HasLocationToSouth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        //向西是否有位置
        public bool HasLocationToWest => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;

        /// <summary>
        /// 是否存在怪物
        /// </summary>
        public bool HasMonster => CurrentMonster != null;

        /// <summary>
        /// 向北移动
        /// </summary>
        public void MoveNorth()
        {
            if (HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }

        /// <summary>
        /// 向南移动
        /// </summary>
        public void MoveSouth()
        {
            if (HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }

        /// <summary>
        /// 向东移动
        /// </summary>
        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
        }

        /// <summary>
        /// 向西移动
        /// </summary>
        public void MoveWest()
        {
            if (HasLocationToWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }

        /// <summary>
        /// 获取当前地点任务
        /// </summary>
        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (CurrentPlayer.Quests.All(q => q.PlayerQuest.ID != quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));

                    RaiseMessage("");
                    RaiseMessage($"你收到 '{quest.Name}' 任务。");
                    RaiseMessage(quest.Description);

                    RaiseMessage("需要物品:");
                    foreach (ItemQuantity itemQuantity in quest.ItemsToComplete)
                    {
                        RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                    }

                    RaiseMessage("获得奖励:");
                    RaiseMessage($"   {quest.RewardExperiencePoints} 经验值");
                    RaiseMessage($"   {quest.RewardGold} 金币");
                    foreach (ItemQuantity itemQuantity in quest.RewardItems)
                    {
                        RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                    }
                }
            }
        }

        /// <summary>
        /// 完成任务地点
        /// </summary>
        private void CompleteQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                //能够完成的任务
                QuestStatus questToComplete =
                    CurrentPlayer.Quests.FirstOrDefault(q => q.PlayerQuest.ID == quest.ID &&
                                                             !q.IsCompleted);

                if (questToComplete != null)
                {
                    if (CurrentPlayer.HasAllTheseItems(quest.ItemsToComplete))
                    {
                        // 从玩家的目录中移除任务完成物品
                        foreach (ItemQuantity itemQuantity in quest.ItemsToComplete)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.ItemTypeId == itemQuantity.ItemID));
                            }
                        }

                        RaiseMessage("");
                        RaiseMessage($"你完成了 '{quest.Name}' 任务");

                        // 获得任务奖励
                        CurrentPlayer.ExperiencePoints += quest.RewardExperiencePoints;
                        RaiseMessage($"你得到 {quest.RewardExperiencePoints} 经验值");

                        CurrentPlayer.Gold += quest.RewardGold;
                        RaiseMessage($"你得到 {quest.RewardGold} 金币");

                        foreach (ItemQuantity itemQuantity in quest.RewardItems)
                        {
                            GameItem rewardItem = ItemFactory.CreateGameItem(itemQuantity.ItemID);

                            CurrentPlayer.AddItemToInventory(rewardItem);
                            RaiseMessage($"你得到{rewardItem.Name}");
                        }

                        // 标记任务完成
                        questToComplete.IsCompleted = true;
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前位置怪物
        /// </summary>
        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        /// <summary>
        /// 攻击当前怪物
        /// </summary>
        public void AttackCurrentMonster()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("你必须选择一种武器来攻击。");
                return;
            }

            // 确定对怪物的伤害
            int damageToMonster = RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

            if (damageToMonster == 0)
            {
                RaiseMessage($"你没有击中{CurrentMonster.Name}.");
            }
            else
            {
                CurrentMonster.CurrentHitPoints -= damageToMonster;
                RaiseMessage($"你击中了 {CurrentMonster.Name} 造成 {damageToMonster} 伤害.");
            }

            // 如果怪物被杀死，收集奖励和战利品
            if (CurrentMonster.CurrentHitPoints <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"你击败了{CurrentMonster.Name}!");

                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExperiencePoints;
                RaiseMessage($"你获得 {CurrentMonster.RewardExperiencePoints} 经验值。");

                CurrentPlayer.Gold += CurrentMonster.Gold;
                RaiseMessage($"你获得 {CurrentMonster.Gold} 金币。");

                foreach (GameItem gameItem in CurrentMonster.Inventory)
                {
                    CurrentPlayer.AddItemToInventory(gameItem);
                    RaiseMessage($"你获得 {gameItem.Name}.");
                }

                // 获取下一个怪物去战斗
                GetMonsterAtLocation();
            }
            else
            {
                // 如果怪物还活着，让怪物攻击
                int damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);

                if (damageToPlayer == 0)
                {
                    RaiseMessage("怪物攻击了你，但没有击中你。");
                }
                else
                {
                    CurrentPlayer.CurrentHitPoints -= damageToPlayer;
                    RaiseMessage($" {CurrentMonster.Name} 击中了你造成{damageToPlayer}伤害");
                }

                //如果玩家被杀，把他们送回他们的家。
                if (CurrentPlayer.CurrentHitPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"{CurrentMonster.Name}击败了你。");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1); // 回家
                    CurrentPlayer.CurrentHitPoints = CurrentPlayer.Level * 10; // 完全治愈玩家
                }
            }
        }

        /// <summary>
        /// 提交信息
        /// </summary>
        /// <param name="message"></param>
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

    }
}
