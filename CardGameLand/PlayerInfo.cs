using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLand
{
    class PlayerInfo
    {
        String nickname;
        int playernum;
        int howmanycard;

        public PlayerInfo()
        {

        }

        public PlayerInfo(String nickname,int playernum,int howmanycard)
        {
            this.nickname = nickname;
            this.playernum = playernum;
            this.howmanycard = howmanycard;
        }

        public bool IsSamePlayer(String nickname)
        {
            return this.nickname.Equals(nickname);
        }

        public String NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public int PlayerNum
        {
            get
            {
                return playernum;
            }
            set
            {
                playernum = value;
            }
        }

        public int HowManyCard
        {
            get
            {
                return howmanycard;
            }
            set
            {
                howmanycard = value;
            }
        }

        public void decreaseCard()
        {
            howmanycard--;
        }

        public void increaseCard(int value)
        {
            howmanycard += value;
        }
    }
}
