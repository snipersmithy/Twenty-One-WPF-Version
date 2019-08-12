using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CardGameClassLibrary;
using System.Windows.Input;
using Quicktools;
using static CardGameClassLibrary.Deck;

namespace Twenty_One_WPF
{
    public partial class App
    {
        // These communicate game state to the player.
        public static string stickortwist = "Do you want to stick or twist?";
        public static string playerinput;
        static string handsummary;

        // Breaks gameplay loop when set to true.
        public static bool gameover = false;

        public static string quit;

        public static int dealerpoints;
        public static int playerpoints;

        // Represents the player's cards and the dealer's cards.
        static List<Card> playerhand = new List<Card>();
        public static List<Card> dealerhand = new List<Card>();

        //Responsible for the initial two card deal and for re-initialising the variables for a new game.
        public static bool initdone = false;
        public static void BeginGame()
        {
            playerhand.Clear();
            dealerhand.Clear();

            dealerpoints = 0;
            playerpoints = 0;

            Console.WriteLine("Dealer to deal two cards...");

            var pc1 = new Card();
            var pc2 = new Card();

            playerhand.AddMany(pc1, pc2);
        }

        //Responsible for reading out the cards the player or the dealer holds.
        public static string SummariseHand()
        {
            handsummary = "";
            for (var i = 0; i < playerhand.Count(); i++)
            {
                if (i == playerhand.Count - 1)
                {
                    handsummary = handsummary + playerhand[i].cardname.ToString() + ".";
                }
                else if (i == playerhand.Count - 2)
                {
                    handsummary = handsummary + playerhand[i].cardname.ToString() + " and the ";
                }
                else if (i < playerhand.Count - 1)
                {
                    handsummary = handsummary + playerhand[i].cardname.ToString() + ", ";
                }
            }
            return "In your hand you have the " + handsummary;
        }

        public static string SummariseDealer()
        {
            handsummary = "";
            for (var i = 0; i < dealerhand.Count(); i++)
            {
                if (i == dealerhand.Count - 1)
                {
                    handsummary = handsummary + dealerhand[i].cardname.ToString() + ".";
                }
                else if (i == dealerhand.Count - 2)
                {
                    handsummary = handsummary + dealerhand[i].cardname.ToString() + " and the ";
                }
                else if (i < dealerhand.Count - 1)
                {
                    handsummary = handsummary + dealerhand[i].cardname.ToString() + ", ";
                }
            }
            return "The Dealer has the " + handsummary;
        }

        // These are responsible for totting up player and dealer points respectively.
        public static int GetPlayerPoints()
        {
            playerpoints = 0;
            for (var i = 0; i < playerhand.Count; i++)
            {
                playerpoints = playerpoints + playerhand[i].cardvalue;
                if (playerpoints > 21 && playerhand[i].cardname.Contains("Ace"))
                {
                    playerpoints = playerpoints - 10;
                }
            }
            return playerpoints;
        }
        public static int GetDealerPoints()
        {
            dealerpoints = 0;
            for (var i = 0; i < dealerhand.Count; i++)
            {
                dealerpoints = dealerpoints + dealerhand[i].cardvalue;
                if (dealerpoints > 21 && dealerhand[i].cardname.Contains("Ace"))
                {
                    dealerpoints = dealerpoints - 10;
                }
            }
            return dealerpoints;
        }
        //Responsible for any deals after the player decides to twist. If the player sticks or is dealt 21 initially this is skipped.
        static public void PlayRound()
        {
            playerhand.Add(new Card());
        }
    }
}
