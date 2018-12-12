using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
namespace CardGameLand
{
    class Deck
    {
        protected Bitmap[] trumpCardImages;
        protected Dictionary<int, Bitmap> decklist;

        public Deck()
        {
            trumpCardImages = new Bitmap[52];
            decklist = new Dictionary<int, Bitmap>();

            //클로버
            trumpCardImages[0] = Properties.Resources.clover_A;
            trumpCardImages[1] = Properties.Resources.clover_2;
            trumpCardImages[2] = Properties.Resources.clover_3;
            trumpCardImages[3] = Properties.Resources.clover_4;
            trumpCardImages[4] = Properties.Resources.clover_5;
            trumpCardImages[5] = Properties.Resources.clover_6;
            trumpCardImages[6] = Properties.Resources.clover_7;
            trumpCardImages[7] = Properties.Resources.clover_8;
            trumpCardImages[8] = Properties.Resources.clover_9;
            trumpCardImages[9] = Properties.Resources.clover_10;
            trumpCardImages[10] = Properties.Resources.clover_J;
            trumpCardImages[11] = Properties.Resources.clover_K;
            trumpCardImages[12] = Properties.Resources.clover_Q;

            //다이아몬드
            trumpCardImages[13] = Properties.Resources.diamond_A;
            trumpCardImages[14] = Properties.Resources.diamond_2;
            trumpCardImages[15] = Properties.Resources.diamond_3;
            trumpCardImages[16] = Properties.Resources.diamond_4;
            trumpCardImages[17] = Properties.Resources.diamond_5;
            trumpCardImages[18] = Properties.Resources.diamond_6;
            trumpCardImages[19] = Properties.Resources.diamond_7;
            trumpCardImages[20] = Properties.Resources.diamond_8;
            trumpCardImages[21] = Properties.Resources.diamond_9;
            trumpCardImages[22] = Properties.Resources.diamond_10;
            trumpCardImages[23] = Properties.Resources.diamond_J;
            trumpCardImages[24] = Properties.Resources.diamond_K;
            trumpCardImages[25] = Properties.Resources.diamond_Q;

            //하트
            trumpCardImages[26] = Properties.Resources.heart_A;
            trumpCardImages[27] = Properties.Resources.heart_2;
            trumpCardImages[28] = Properties.Resources.heart_3;
            trumpCardImages[29] = Properties.Resources.heart_4;
            trumpCardImages[30] = Properties.Resources.heart_5;
            trumpCardImages[31] = Properties.Resources.heart_6;
            trumpCardImages[32] = Properties.Resources.heart_7;
            trumpCardImages[33] = Properties.Resources.heart_8;
            trumpCardImages[34] = Properties.Resources.heart_9;
            trumpCardImages[35] = Properties.Resources.heart_10;
            trumpCardImages[36] = Properties.Resources.heart_J;
            trumpCardImages[37] = Properties.Resources.heart_K;
            trumpCardImages[38] = Properties.Resources.heart_Q;

            //스페이스
            trumpCardImages[39] = Properties.Resources.space_A;
            trumpCardImages[40] = Properties.Resources.space_2;
            trumpCardImages[41] = Properties.Resources.space_3;
            trumpCardImages[42] = Properties.Resources.space_4;
            trumpCardImages[43] = Properties.Resources.space_5;
            trumpCardImages[44] = Properties.Resources.space_6;
            trumpCardImages[45] = Properties.Resources.space_7;
            trumpCardImages[46] = Properties.Resources.space_8;
            trumpCardImages[47] = Properties.Resources.space_9;
            trumpCardImages[48] = Properties.Resources.space_10;
            trumpCardImages[49] = Properties.Resources.space_J;
            trumpCardImages[50] = Properties.Resources.space_K;
            trumpCardImages[51] = Properties.Resources.space_Q;

        }
    }
}
