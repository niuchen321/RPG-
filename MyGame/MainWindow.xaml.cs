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
        /// 向北移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveNorth_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveNorth();
        }

        /// <summary>
        /// 向南移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveSouth_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }

        /// <summary>
        /// 向东移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveEast_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }

        /// <summary>
        /// 向西移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveWest_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }
    }
}
