using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
