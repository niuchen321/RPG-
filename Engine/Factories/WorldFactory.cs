using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
   internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "农民的田地",
                "这里生长着成排的玉米，中间藏着巨大的老鼠。",
                "/Engine;component/Images/Locations/FarmFields.png");

            newWorld.AddLocation(-1, -1, "农民的房子",
                "这是你邻居农夫泰德的房子。",
                "/Engine;component/Images/Locations/Farmhouse.png");

            newWorld.AddLocation(0, -1, "家",
                "这是你的房子",
                "/Engine;component/Images/Locations/Home.png");

            newWorld.AddLocation(-1, 0, "贸易商店",
                "商人苏珊的商店。",
                "/Engine;component/Images/Locations/Trader.png");

            newWorld.AddLocation(0, 0, "城市广场",
                "你在这里看到一个喷泉。",
                "/Engine;component/Images/Locations/TownSquare.png");

            newWorld.AddLocation(1, 0, "城堡之门",
                "这里有一扇门，保护小镇免受巨蜘蛛的侵袭。",
                "/Engine;component/Images/Locations/TownGate.png");

            newWorld.AddLocation(2, 0, "蜘蛛森林",
                "这片森林里的树都结满了蜘蛛网。",
                "/Engine;component/Images/Locations/SpiderForest.png");

            newWorld.AddLocation(0, 1, "草药医生的小屋",
                "你看到一个小茅屋，屋顶上正在晾干草药。.",
                "/Engine;component/Images/Locations/HerbalistsHut.png");

            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "草药医生的花园",
                "这里有许多植物，它们后面藏着蛇。",
                "/Engine;component/Images/Locations/HerbalistsGarden.png");
            
            return newWorld;
        }
    }
}
