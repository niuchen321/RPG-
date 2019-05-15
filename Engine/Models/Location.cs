using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    /// <summary>
    /// 角色位置
    /// </summary>
   public class Location
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public int XCoordinate { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int YCoordinate { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 任务
        /// </summary>
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
        /// <summary>
        /// 怪物位置
        /// </summary>
        public List<MonsterEncounter> MonstersHere { get; set; } =
            new List<MonsterEncounter>();

        /// <summary>
        /// 商店位置
        /// </summary>
        public Trader TraderHere { get; set; }

        /// <summary>
        /// 根据怪物ID和出现概率添加怪物
        /// </summary>
        /// <param name="monsterId">怪物ID</param>
        /// <param name="chanceOfEncountering">出现概率</param>
        public void AddMonster(int monsterId, int chanceOfEncountering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterId))
            {
                //这个怪物已经被添加到这个位置。
                //所以，用这个新数字来表示遇到的可能性。
                MonstersHere.First(m => m.MonsterID == monsterId)
                    .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                // 这个怪物还没有在这个位置，所以添加它。
                MonstersHere.Add(new MonsterEncounter(monsterId, chanceOfEncountering));
            }
        }

        /// <summary>
        /// 获取怪物
        /// </summary>
        /// <returns></returns>
        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            // 计算此位置所有怪物的概率
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // 选择一个介于1和总数之间的随机数(以防总数不是100)。
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            //运行总数
            int runningTotal = 0;

            //循环遍历怪物列表，将怪物出现的概率百分比添加到runningTotal变量中。
            //当随机数低于运行总数时，这就是要返回的怪物。
            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // 如果有问题，返回列表的最后一个怪物
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}
