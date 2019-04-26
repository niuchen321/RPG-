using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    /// <summary>
    /// 游戏动作
    /// </summary>
   public class GameSession
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        public Player CurrentPlayer { get; set; }
        /// <summary>
        /// 当前位置信息
        /// </summary>
        public Location CurrentLocation { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player()
            {
                Name = "晨",
                Gold = 10000,
                CharacterClass="战士",
                ExperiencePoints=0,
                HitPoints=10,
                Level=0
            };

            CurrentLocation = new Location()
            {
                XCoordinate = 0,
                YCoordinate = -1,
                Name = "家",
                Description = "这是你的房子",
                ImageName = "/Engine;component/Images/Locations/Home.png"
            };
        }

       
    }
}
