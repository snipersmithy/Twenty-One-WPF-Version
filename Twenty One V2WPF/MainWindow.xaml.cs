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
using static Twenty_One_WPF.App;

namespace Twenty_One_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Responsible for the UI.

        public static void Game()
        {

            if (GetPlayerPoints() < 21)
            {
                Console.WriteLine();
                Console.WriteLine(SummariseHand());

                Console.WriteLine("These are worth " + GetPlayerPoints() + " points.");
                Console.WriteLine(stickortwist);
                playerinput = Console.ReadLine();

            }
            else if (GetPlayerPoints() == 21)
            {
                Console.WriteLine();
                Console.WriteLine("21! Dealer must match your score to win...");
                DealerRound();
            }
            else if (GetPlayerPoints() > 21)
            {
                Console.WriteLine();
                Console.WriteLine(SummariseHand());
                Console.WriteLine("Bust! Unlucky...");
            }
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

                    Debug.WriteLine("Do you want to play again? (Press Enter to continue or type 'quit' to end game.)");
                    quit = "test";
                    if (quit.ToLower() == "quit")
                        gameover = true;
                    else
                    {
                        initdone = false;
                    }
        }
    }
}



