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
using System.Diagnostics;
using Twenty_One_WPF;
using static Twenty_One_WPF.App;
using Quicktools;
using static CardGameClassLibrary.Deck;

namespace Twenty_One_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Responsible for the UI.
        
        public void Game()
        {
            if (GetPlayerPoints() < 21)
            {
                status.Content = SummariseHand() + " These are worth " + GetPlayerPoints() + " points. \n" + stickortwist;
            }
            else if (GetPlayerPoints() == 21)
            {
                status.Content = SummariseHand() + "\n21! Dealer must match your score to win...";
                DealerRound();
            }
            else if (GetPlayerPoints() > 21)
            {
                status.Content = SummariseHand()+ " These are worth " + GetPlayerPoints() + " points." + "\nBust! Unlucky...";
            }
        }
        //Responsible for the dealer's cards being drawn and the dealer's decision making.
        public void DealerRound()
        {
            dealerhand.AddMany(new Card(), new Card());
            status.Content = SummariseDealer() + "\nThese are worth " + GetDealerPoints() + " points.";

            do
            {
                dealerhand.Add(new Card());
                status.Content = "Dealer twists!\n" + SummariseDealer() + "\nThese are worth " + GetDealerPoints() + " points. ";

                if (GetDealerPoints() > 21)
                {
                    status.Content = SummariseDealer() + " Dealer is bust... You Win!";
                }
                else if (GetDealerPoints() > GetPlayerPoints() && GetDealerPoints() <= 21)
                {
                    status.Content = "Dealer Wins! Dealer has " + GetDealerPoints() + " points and you only have " + GetPlayerPoints() + " points. Unlucky!";
                }
                else if (GetDealerPoints() == GetPlayerPoints())
                {
                    status.Content = SummariseDealer() + " Dealer gets house advantage, Dealer wins with " + GetDealerPoints() + " points.";
                }
                status.Content += "\nDo you want to play again? (Press Game to start over or Quit to end.";
            } while (GetDealerPoints() < 22 && GetDealerPoints() < GetPlayerPoints());
        }
        public void Stick_MouseUp(object sender1, MouseButtonEventArgs e)
        {
            Debug.WriteLine("stuck");
            DealerRound();
        }

        public void Twist_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("twisted");
            PlayRound();
            if (GetPlayerPoints() < 21)
            {
                status.Content = SummariseHand() + " These are worth " + GetPlayerPoints() + " points. \n" + stickortwist;
            }
            else if (GetPlayerPoints() == 21)
            {
                status.Content = SummariseHand() + "\n21! Dealer must match your score to win...";
                DealerRound();
            }
            else if (GetPlayerPoints() > 21)
            {
                status.Content = SummariseHand() + "\nBust! Unlucky...";
            }
        }

        private void Play_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("started");
                    if (initdone == false)
                    {
                        BeginGame();
                        initdone = true;
                    }

                    Game();

                    initdone = false;
                    
        }

        private void Quit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}



