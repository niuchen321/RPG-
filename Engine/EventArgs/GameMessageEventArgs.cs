using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.EventArgs
{
    /// <summary>
    /// 游戏信息事件
    /// </summary>
    public class GameMessageEventArgs : System.EventArgs
    {
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; private set; }

        public GameMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
