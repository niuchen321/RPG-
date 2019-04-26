using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 发现怪物
    /// </summary>
    public class MonsterEncounter
    {
        /// <summary>
        /// 怪物ID
        /// </summary>
        public int MonsterID { get; set; }
        /// <summary>
        /// 出现概率
        /// </summary>
        public int ChanceOfEncountering { get; set; }

        public MonsterEncounter(int monsterID, int chanceOfEncountering)
        {
            MonsterID = monsterID;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
