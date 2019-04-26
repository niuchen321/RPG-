using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 任务状态
    /// </summary>
   public class QuestStatus
    {
        /// <summary>
        /// 进行任务
        /// </summary>
        public Quest PlayerQuest { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsCompleted { get; set; }

        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
