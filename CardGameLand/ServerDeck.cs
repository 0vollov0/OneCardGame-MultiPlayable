using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace CardGameLand
{
    class ServerDeck : Deck
    {
        private int[] deck;
        private int top;
        private int[] dumydeck;
        private int dumytop;
        private int currenttop;
        public ServerDeck() : base()
        {
            
            deck = new int[52]; top = 52;
            dumydeck = new int[52]; dumytop = -1;

            for (int i = 0, k = 100; i < 52; i++, k++)
            {
                if (k % 100 > 12)
                {
                    k = (k / 100 + 1) * 100;
                }
                deck[i] = k;
                decklist.Add(k, trumpCardImages[i]);
            }

            Shuffle();
            pushDumy(Draw());

        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int n = top -1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                int temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }

        public int Draw()
        {
            top--;
            return deck[top];
        }
        public void changeDeckDumy()
        {
            for (int i = 0; i < dumytop-1; i++)
            {
                deck[i] = dumydeck[i];
            }
            top = dumytop - 1;
            dumydeck[0] = dumydeck[dumytop];
            dumytop = 0;
        }
        public void SetCurrentTop(int cardNum)
        {
            currenttop = cardNum;
        }
        public int GetCurrentTop()
        {
            return currenttop;
        }
        public int getTop()
        {
            return top;
        }

        public int getDumyTop()
        {
            return currenttop;
        }

        public void pushDumy(int value)
        {
            dumytop++;
            dumydeck[dumytop] = value;
            currenttop = dumydeck[dumytop];
        }

        public void pushDeadCards(int value)
        {
            int temp = dumydeck[dumytop];
            dumydeck[dumytop] = value;
            pushDumy(temp);
        }
    }
}
