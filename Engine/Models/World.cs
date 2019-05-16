using System.Collections.Generic;

namespace Engine.Models
{
   public class World
   {
        //位置信息集合
       private readonly List<Location> _locations = new List<Location>();

        /// <summary>
        /// 添加位置信息
        /// </summary>
       internal void AddLocation(int xCoordinate, int yCoordinate,
           string name, string description, string imageName)
       {
           _locations.Add(new Location(xCoordinate, yCoordinate, name, description,
               $"/Engine;component/Images/Locations/{imageName}"));
       }


        /// <summary>
        /// 根据坐标获取位置
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <returns>位置信息</returns>
        public Location LocationAt(int x, int y)
       {
           foreach (var location in _locations)
           {
               if (location.XCoordinate==x&&location.YCoordinate==y)
               {
                   return location;
               }
           }

           return null;
       }
   }
}
