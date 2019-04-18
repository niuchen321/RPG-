using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.ViewModels;

namespace MyGame
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;

        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();

            DataContext = _gameSession;
        }

        /// <summary>
        /// 增加经验值事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddExperiencePoints_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.ExperiencePoints += 10;
        }
    }
}
