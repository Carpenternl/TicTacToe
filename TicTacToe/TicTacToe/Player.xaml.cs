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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        public delegate void DeleteHandler(object sender, RoutedEventArgs e);
        public event DeleteHandler onDelete;
        public Player()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            onDelete(this, e);
        }

        private void PlayerName_Click(object sender, RoutedEventArgs e)
        {
            ToggleVisibility(PlayerEdit, PlayerName);
            PlayerEdit.Focus();
        }

        private void ToggleVisibility(UIElement a, UIElement b)
        {
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Hidden;
        }

        private void PlayerEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            PlayerName.Content = PlayerEdit.Text;
            ToggleVisibility(PlayerName, PlayerEdit);
        }
    }
}
