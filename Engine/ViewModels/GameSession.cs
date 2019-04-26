using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    /// <summary>
    /// 游戏动作
    /// </summary>
    public class GameSession : BaseNotificationClass
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        public Player CurrentPlayer { get; set; }

        private Location _currentLocation;

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

                GivePlayerQuestsAtLocation();
            }
        }

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
                HitPoints = 10,
                Level = 0
            };
            
            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 1);
        }

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
                }
            }
        }
    }
}
