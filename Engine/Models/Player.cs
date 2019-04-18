using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// 玩家状态
    /// </summary>
    public class Player : INotifyPropertyChanged
    {
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// 角色类型
        /// </summary>
        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged("CharacterClass");
            }
        }

        /// <summary>
        /// 生命值
        /// </summary>
        public int HitPoints
        {
            get => _hitPoints;
            set
            {
                _hitPoints = value;
                OnPropertyChanged("HitPoints");
            }
        }
        /// <summary>
        /// 经验值
        /// </summary>
        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
            }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level
        {
            get => _level; set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }
        /// <summary>
        /// 金币
        /// </summary>
        public int Gold
        {
            get => _gold; set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性修改事件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
