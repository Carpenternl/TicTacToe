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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        private Player Template;
        int Totalplayers = 0;

        public NewGame()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Player newb = new Player();
            newb.PlayerName.Content = "newb".PadRight(50,' ');
            newb.onDelete += Newb_onDelete;
            this.Players.Children.Insert(0,newb);
            this.Totalplayers = this.Players.Children.Count - 1;
            if (Totalplayers >= 9)
            {
                ((Button)sender).Visibility = Visibility.Hidden;
            }
        }

        private void Newb_onDelete(object sender, RoutedEventArgs e)
        {
            this.Players.Children.Remove((sender as Player));
            this.Totalplayers = this.Players.Children.Count - 1;
            Totalplayers = Math.Max(Totalplayers, 0);
            if (Totalplayers < 9)
            {
                Players.Children[Players.Children.Count - 1].Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Template = this.Players.Children[0] as Player;
            this.Players.Children.RemoveAt(0);
        }
    }
}
