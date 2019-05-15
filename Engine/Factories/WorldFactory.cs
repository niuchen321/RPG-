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
                "FarmFields.png");
            //添加老鼠
            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "农民的房子",
                "这是你邻居农夫泰德的房子。",
                "Farmhouse.png");
            newWorld.LocationAt(-1, -1).TraderHere =
                TraderFactory.GetTraderByName("农夫泰德");

            newWorld.AddLocation(0, -1, "家",
                "这是你的房子",
                "Home.png");

            newWorld.AddLocation(-1, 0, "贸易商店",
                "商人苏珊的商店。",
                "Trader.png");
            newWorld.LocationAt(-1, 0).TraderHere =
                TraderFactory.GetTraderByName("苏珊");

            newWorld.AddLocation(0, 0, "城市广场",
                "你在这里看到一个喷泉。",
                "TownSquare.png");

            newWorld.AddLocation(1, 0, "城堡之门",
                "这里有一扇门，保护小镇免受巨蜘蛛的侵袭。",
                "TownGate.png");

            newWorld.AddLocation(2, 0, "蜘蛛森林",
                "这片森林里的树都结满了蜘蛛网。",
                "SpiderForest.png");
            //添加蜘蛛
            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "草药医生的小屋",
                "你看到一个小茅屋，屋顶上正在晾干草药。.",
                "HerbalistsHut.png");
            newWorld.LocationAt(0, 1).TraderHere =
                TraderFactory.GetTraderByName("草药医生皮特");
            //添加除蛇任务
            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestById(1));

            newWorld.AddLocation(0, 2, "草药医生的花园",
                "这里有许多植物，它们后面藏着蛇。",
                "HerbalistsGarden.png");
            //添加蛇
            newWorld.LocationAt(0, 2).AddMonster(1, 100);
            return newWorld;
        }
    }
}
