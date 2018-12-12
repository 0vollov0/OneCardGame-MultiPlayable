using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace CardGameLand
{
    class ClientDeck : Deck
    {
        public ClientDeck() : base()
        {
            for (int i = 0, k = 100; i < 52; i++, k++)
            {
                if (k % 100 > 12)
                {
                    k = (k / 100 + 1) * 100;
                }
                decklist.Add(k, trumpCardImages[i]);
            }
        }

        public Dictionary<int, Bitmap> DeckList
        {
            get
            {
                return decklist;
            }
        }
    }
}
