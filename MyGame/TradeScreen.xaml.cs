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
using System.Windows.Shapes;
using Engine.Models;
using Engine.ViewModels;

namespace MyGame
{
    /// <summary>
    /// TradeScreen.xaml 的交互逻辑
    /// </summary>
    public partial class TradeScreen : Window
    {
        /// <summary>
        /// 游戏操作
        /// </summary>
        public GameSession Session => DataContext as GameSession;

        public TradeScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 出售
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem =
                ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedInventoryItem != null)
            {
                Session.CurrentPlayer.ReceiveGold (groupedInventoryItem.Item.Price);
                Session.CurrentTrader.AddItemToInventory(groupedInventoryItem.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);
            }
        }

        /// <summary>
        /// 购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem =
                ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedInventoryItem != null)
            {
                if (Session.CurrentPlayer.Gold >= groupedInventoryItem.Item.Price)
                {
                    Session.CurrentPlayer.SpendGold(groupedInventoryItem.Item.Price);
                    Session.CurrentTrader.RemoveItemFromInventory(groupedInventoryItem.Item);
                    Session.CurrentPlayer.AddItemToInventory(groupedInventoryItem.Item);
                }
                else
                {
                    MessageBox.Show("金币不足，无法购买！");
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
