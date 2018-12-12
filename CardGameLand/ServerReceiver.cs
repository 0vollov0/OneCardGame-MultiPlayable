using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
namespace CardGameLand
{
    class ServerReceiver
    {
        TcpClient tcpClient;
        TextBox textBoxChattingList;
        RoomInfo roomInformation;

        NetworkStream ns;
        BinaryReader br;
        BinaryWriter bw;

        static Mutex mut = new Mutex();

        ServerCommand serverCommand;
        Dictionary<String, BinaryWriter> clients;
        OneCard Game;
        public ServerReceiver(TcpClient tcpClient, Dictionary<String, BinaryWriter> clients, TextBox textBoxChattingList, RoomInfo roomInformation, OneCard Game)
        {
            this.tcpClient = tcpClient;
            this.textBoxChattingList = textBoxChattingList;
            this.roomInformation = roomInformation;
            this.clients = clients;
            this.Game = (OneCard)Game;
            ns = this.tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
            serverCommand = new ServerCommand(br, bw, clients);
        }

        public void process()
        {
            String NickName="";
            try
            {
                //원카드 게임ID
                NickName = br.ReadString();

                if (clients.ContainsKey(NickName))
                {
                    while (clients.ContainsKey(NickName))
                    {
                        bw.Write(Command.ReMakeNickName);
                        NickName = br.ReadString();
                    }
                }
                bw.Write(Command.AvailableNickName);
                bw.Write(roomInformation.Title);
                bw.Write(roomInformation.GameID);
                bw.Write(roomInformation.MaxPersonCount);

                String welcomeMsg;
                welcomeMsg = NickName + "님이 입장하셨습니다.";

                serverCommand.AddClient(NickName, bw);

                serverCommand.PlayerCount++;
                if (serverCommand.PlayerCount >= roomInformation.MaxPersonCount)
                {
                    Game.CloseGameRoom();
                }

                mut.WaitOne();
                serverCommand.AddPlayer(NickName);
                serverCommand.AddPlayerTurn(NickName);
                mut.ReleaseMutex();
                serverCommand.Message(Command.SendMessage, welcomeMsg);
                serverCommand.CurrentPlayerCount(Command.SendCurrentPersonCount);
                string nickname;
                while (bw != null)
                {
                    int command = br.ReadInt32();
                    switch (command)
                    {
                        case Command.SendMessage:
                            String msg = br.ReadString();
                            serverCommand.Message(command, msg);
                            break;
                        case Command.FistDraw:
                            serverCommand.InitPlaySetting(command);
                            break;
                        case Command.PutCard:
                            int newdumy = br.ReadInt32();
                            nickname = br.ReadString();
                            int dumy = ServerCommand.deck.getDumyTop();
                            serverCommand.SetCard(command, dumy, newdumy, nickname);
                            break;
                        case Command.Die:
                            int count = br.ReadInt32();
                            serverCommand.SomeoneDie(command, count);
                            break;
                        case Command.Draw:
                            nickname = br.ReadString();
                            serverCommand.Draw(command, nickname);
                            break;
                        case Command.OneCard:
                            nickname = br.ReadString();
                            serverCommand.EnableOneCardButton(nickname);
                            break;
                        case Command.SucessOneCard:
                            serverCommand.SucessOneCard();
                            break;
                        case Command.BlockOneCard:
                            nickname = br.ReadString();
                            serverCommand.BlockOneCard(nickname);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (IOException e)
            {

            }
            finally
            {
                serverCommand.RemoveClient(NickName);
                mut.WaitOne();
                ServerCommand.players.Remove(NickName);
                ServerCommand.playerturn.RemovePlayer(NickName);
                mut.ReleaseMutex();
                serverCommand.Message(Command.SendMessage, NickName + "님이 게임을 종료하셨습니다.");
                serverCommand.PlayerCount--;
                if (Game.GetStateAcceptThread()!= true)
                {
                    Game.OpenGameRoom();
                }
                serverCommand.CurrentPlayerCount(Command.SendCurrentPersonCount);
                serverCommand.RemovePlayer(Command.RemovePlayer,NickName);

                if (serverCommand.PlayerCount == 1 && Game.GetStateStartButton() == false)
                {
                    serverCommand.YouWin(ServerCommand.playerturn.GetCurrentPlayerTurn());
                }
            }
        }
    }
}

