using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
namespace CardGameLand
{
    class ServerCommand
    {
        BinaryReader br;
        BinaryWriter bw;
        Dictionary<String, BinaryWriter> clients;
        public static Dictionary<String, PlayerInfo> players = new Dictionary<string, PlayerInfo>();
        public static ServerDeck deck = new ServerDeck();
        public static PlayerTurn playerturn = new PlayerTurn();

        public static int playercount = 0;
        public static int attackstack = 1;
        
        public ServerCommand(BinaryReader br, BinaryWriter bw, Dictionary<String, BinaryWriter> clients)
        {
            this.br = br;
            this.bw = bw;
            this.clients = clients;
        }

        public int PlayerCount
        {
            get
            {
                return playercount;
            }
            set
            {
                playercount = value;
            }
        }

        public int AttackStack
        {
            get
            {
                return attackstack;
            }
            set
            {
                attackstack = value;
            }
        }

        public Dictionary<String, BinaryWriter> Clients
        {
            get
            {
                return clients;
            }
        }

        public void AddClient(String nickname,BinaryWriter bw)
        {
            clients.Add(nickname, bw);
        }

        public void RemoveClient(String nickname)
        {
            clients.Remove(nickname);
        }

        public Dictionary<String, PlayerInfo> Players
        {
            get
            {
                return players;
            }
        }

        public void AddPlayer(String nickname)
        {
            players.Add(nickname, new PlayerInfo(nickname,playercount,6));
        }

        public PlayerTurn PlayerTurn
        {
            get
            {
                return playerturn;
            }
        }

        public void AddPlayerTurn(String nickname)
        {
            playerturn.AddPlayer(nickname);
        }

        public void Message(int command, String message)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(command);
                bw.Write(message);
            }
        }

        public void CurrentPlayerCount(int command)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(command);
                bw.Write(playercount);
            }
        }

        public void RePaintPlayer(int command)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(command);
                bw.Write(playercount);
                bw.Write(client.Key);
            }
        }

        public void RemovePlayer(int command,String nickname)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(command);
                bw.Write(nickname);
            }
        }

        public void InitPlaySetting(int command)
        {
            int fistdrawcount = 6;
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;

                bw.Write(command);
                bw.Write(deck.getDumyTop());
                bw.Write(fistdrawcount);
                for (int i = 0; i < fistdrawcount; i++)
                {
                    bw.Write(deck.Draw());
                }

                bw.Write(players.Count);
                foreach (KeyValuePair<String, PlayerInfo> player in players)
                {
                    bw.Write(player.Value.NickName);
                    bw.Write(player.Value.PlayerNum);
                    bw.Write(player.Value.HowManyCard);
                }

                bw.Write(playerturn.GetCurrentPlayerTurn());
            }
        }
        public void SetCard(int command,int dumy,int newdumy,String nickname)
        {
            if (checkRegular(dumy, newdumy))
            {
                if (AttackStack == 1)
                {
                    deck.pushDumy(newdumy);
                    if (newdumy % 100 <= 1)
                    {
                        AttackStack += (3 - (newdumy % 100 + 1));
                    }
                    if (newdumy % 100 == 6)
                    {
                        int temp = ChangeKind(nickname);
                        
                        deck.SetCurrentTop(temp);
                    }
                    SendSetCard(command, deck.getDumyTop(),newdumy, nickname);
                }
                else
                {
                    if (newdumy % 100 <= 1)
                    {
                        AttackStack += (3 - (newdumy % 100 + 1));
                        deck.pushDumy(newdumy);
                        SendSetCard(command, deck.getDumyTop(), newdumy, nickname);
                    }
                    else if (newdumy % 100 == 2 && deck.getDumyTop() + 1 == newdumy)
                    {
                        AttackStack = 1;
                        deck.pushDumy(newdumy);
                        SendSetCard(command, deck.getDumyTop(), newdumy, nickname);
                    }

                }
            }
        }
        private void SendSetCard(int command,int cardnumber,int removeowner,String nickname)
        {
            if (command == Command.PutCard)
            {
                if (cardnumber % 100 >= 10)
                {
                    
                    playerturn.ChangeTurnCard(cardnumber % 100);
                }
                else
                {
                    playerturn.NextPlayerTurn();
                }
                foreach (KeyValuePair<String, BinaryWriter> client in clients)
                {
                    BinaryWriter bw = (BinaryWriter)client.Value;
                    bw.Write(command);
                    bw.Write(cardnumber);
                    bw.Write(nickname);
                    bw.Write(playerturn.GetCurrentPlayerTurn());
                }
                players[nickname].HowManyCard--;
                clients[nickname].Write(Command.PutCardOnwer);
                clients[nickname].Write(removeowner);

                if (players[nickname].HowManyCard == 0)
                {
                    YouWin(players[nickname].NickName);
                }
            }
        }

        public int ChangeKind(int command,String nickname)
        {
            clients[nickname].Write(command);
            int kind = br.ReadInt32();
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(Command.ChangeKindMessage);
                bw.Write(nickname);
                bw.Write(kind);
            }
            return kind;
        }

        public void Draw(int command, String nickname)
        {
            playerturn.NextPlayerTurn();
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(command);
                bw.Write(AttackStack);
                bw.Write(nickname);
                bw.Write(playerturn.GetCurrentPlayerTurn());
            }
            clients[nickname].Write(Command.DrawOnwer);
            clients[nickname].Write(AttackStack);
            for (int i = 0; i < AttackStack; i++)
            {
                clients[nickname].Write(deck.Draw());
                players[nickname].HowManyCard++;
            }
            AttackStack = 1;

            if (players[nickname].HowManyCard > 9)
            {
                playerturn.RemovePlayer(nickname);
                players.Remove(nickname);
            }

            if (players.Count == 1)
            {
                foreach (KeyValuePair<String, PlayerInfo> player in players)
                {
                    YouWin(player.Key);
                }
            }
        }

        public void SomeoneDie(int command,int count)
        {
            for (int i = 0; i < count; i++)
            {
                deck.pushDeadCards(br.ReadInt32());
            }
        }

        public void YouWin(String nickname)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(Command.Win);
                bw.Write(nickname);
            }
        }

        public void EnableOneCardButton(String nickname)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(Command.EnableOneCardButton);
                bw.Write(nickname);
            }
            
        }

        public void SucessOneCard()
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(Command.DisableOneCardButton);
            }
        }


        public void BlockOneCard(String nickname)
        {
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(Command.Draw);
                bw.Write(1);
                bw.Write(nickname);
                bw.Write(playerturn.GetCurrentPlayerTurn());
            }
            clients[nickname].Write(Command.DrawOnwer);
            clients[nickname].Write(1);
            clients[nickname].Write(deck.Draw());
            players[nickname].HowManyCard++;

            if (players[nickname].HowManyCard > 9)
            {
                playerturn.RemovePlayer(nickname);
                players.Remove(nickname);
            }

            if (players.Count == 1)
            {
                foreach (KeyValuePair<String, PlayerInfo> player in players)
                {
                    YouWin(player.Key);
                }
            }
            SucessOneCard();
        }

        private bool checkRegular(int dumy, int newdumy)
        {
            int temp1 = dumy / 100;
            int temp2 = newdumy / 100;

            if (temp1 == temp2) return true;

            temp1 = dumy % 100;
            temp2 = newdumy % 100;

            if (temp1 == temp2) return true;

            return false;
        }

        private int ChangeKind(String NickName)
        {
            clients[NickName].Write(Command.ChangeKind);
            int kind = br.ReadInt32();
            foreach (KeyValuePair<String, BinaryWriter> client in clients)
            {
                BinaryWriter bw = (BinaryWriter)client.Value;
                bw.Write(Command.ChangeKindMessage);
                bw.Write(NickName);
                bw.Write(kind);
            }
            return kind;
        }
    }
}
