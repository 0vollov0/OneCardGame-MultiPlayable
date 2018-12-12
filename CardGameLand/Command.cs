using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLand
{
    class Command
    {
        public const int SendMessage = 0;
        public const int SendCurrentPersonCount = 1;
        public const int RePaintPlayer =10;
        public const int SendPaintRemovePlayer = 11;
        public const int RemovePlayer = 12;
        public const int ReMakeNickName = 13;
        public const int AvailableNickName = 14;
        public const int FistDraw = 20;
        public const int playerSetting = 21;
        public const int PutCard = 30;
        public const int PutCardOnwer = 31;
        public const int Draw = 40;
        public const int DrawOnwer = 41;
        public const int Die = 42;
        public const int Win = 43;
        public const int ChangeKind = 50;
        public const int ChangeKindMessage = 51;
        public const int OneCard = 100;
        public const int EnableOneCardButton = 101;
        public const int DisableOneCardButton = 102;
        public const int SucessOneCard = 103;
        public const int BlockOneCard = 104;

    }
}
