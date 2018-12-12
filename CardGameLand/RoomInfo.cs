using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLand
{
    public class RoomInfo
    {
        string title;
        string password;
        int gameID;
        int maxpersoncount;

        public RoomInfo()
        {

        }

        public RoomInfo(string title, string password, int gameID, int maxpersoncount)
        {
            this.title = title;
            this.password = password;
            this.gameID = gameID;
            this.maxpersoncount = maxpersoncount;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public int GameID
        {
            get
            {
                return gameID;
            }
            set
            {
                gameID = value;
            }
        }

        public int MaxPersonCount
        {
            get
            {
                return maxpersoncount;
            }
            set
            {
                maxpersoncount = value;
            }
        }

        
    }
}
