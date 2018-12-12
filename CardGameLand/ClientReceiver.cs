using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Threading;

namespace CardGameLand
{
    class ClientReceiver
    {
        TextBox textBoxChattingList;
        Label labelCurrentPersonCount;
        BinaryReader br;
        BinaryWriter bw;
        OneCard Game;

        List<int> mycards;
        int currentPersonCount;

        static Mutex mut = new Mutex();
        Dictionary<String, PlayerInfo> players;
        String MyNickName;
        public ClientReceiver(BinaryReader br,BinaryWriter bw ,TextBox textBoxChattingList,Label labelCurrentPersonCount, OneCard Game, List<int> mycards, Dictionary<String, PlayerInfo> players,String Nickname)
        {
            this.br = br;
            this.bw = bw;
            this.textBoxChattingList = textBoxChattingList;
            this.labelCurrentPersonCount = labelCurrentPersonCount;
            this.Game = (OneCard)Game;
            this.mycards = mycards;
            this.players = players;
            this.MyNickName = Nickname;
        }

        public void process()
        {
            String NickName;
            int attackstack;
            while (br!=null)
            {
                
                int command = br.ReadInt32();
                switch (command)
                {
                    case Command.SendMessage:
                        string msg = br.ReadString();
                        try
                        {
                            textBoxChattingList.AppendText(msg + Environment.NewLine);
                        }
                        catch (Exception)
                        {
                        }
                        
                        break;
                    case Command.SendCurrentPersonCount:
                        int currentPersonCount = br.ReadInt32();
                        try
                        {
                            labelCurrentPersonCount.Text = Convert.ToString(currentPersonCount);
                        }
                        catch (Exception)
                        {
                        }
                        
                        break;
                    case Command.RemovePlayer:
                        players.Remove(br.ReadString());
                        Game.Invalidate();
                        break;
                    case Command.FistDraw:
                        Game.setDumytop(br.ReadInt32());
                        int cnt = br.ReadInt32();
                        for (int i = 0; i < cnt; i++)
                        {
                            mycards.Add(br.ReadInt32());
                        }

                        int playerCount;
                        int playernum;
                        int howmanycard;

                        playerCount = br.ReadInt32();

                        for (int i = 0; i < playerCount; i++)
                        {
                            NickName = br.ReadString();
                            playernum = br.ReadInt32();
                            howmanycard = br.ReadInt32();
                            Game.addPlayerInfo(NickName, playernum, howmanycard);
                        }
                        Game.setTurn(br.ReadString());
                        Game.Invalidate();
                        break;
                    case Command.PutCard:
                        Game.setDumytop(br.ReadInt32());
                        players[br.ReadString()].decreaseCard();
                        Game.setTurn(br.ReadString());
                        Game.Invalidate();
                        break;
                    case Command.PutCardOnwer:
                        int removeCardNum = br.ReadInt32();
                        mycards.Remove(removeCardNum);
                        if (mycards.Count == 1)
                        {
                            bw.Write(Command.OneCard);
                            bw.Write(MyNickName);
                        }
                        Game.Invalidate();
                        break;
                    case Command.Draw:
                        attackstack = br.ReadInt32();
                        NickName = br.ReadString();
                        players[NickName].increaseCard(attackstack);
                        if (players[NickName].HowManyCard > 9)
                        {
                            players.Remove(NickName);
                        }
                        Game.setTurn(br.ReadString());
                        Game.Invalidate();
                        break;
                    case Command.DrawOnwer:
                        attackstack = br.ReadInt32();
                        for (int i = 0; i < attackstack; i++)
                        {
                            mycards.Add(br.ReadInt32());
                        }
                        if (mycards.Count > 9)
                        {
                            Game.Die();
                        }
                        Game.Invalidate();
                        break;
                    case Command.Win:
                        NickName = br.ReadString();

                        Game.setWinPlayer(NickName);
                        Game.Invalidate();
                        break;
                    case Command.ChangeKind:
                        string message = "클로버로 바꾸시겠습니까?";
                        string caption = "종류 선택";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            bw.Write(106);
                        }
                        else
                        {
                            message = "다이아로 바꾸시겠습니까?";
                            result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                bw.Write(206);
                            }
                            else
                            {
                                message = "하트로 바꾸시겠습니까?";
                                result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    bw.Write(306);
                                }
                                else
                                {
                                    message = "스페이스로 바꾸시겠습니까?";
                                    result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        bw.Write(406);
                                    }
                                    else
                                    {
                                        bw.Write(406);
                                    }
                                }
                            }
                        }
                        break;
                    case Command.ChangeKindMessage:
                        NickName = br.ReadString();
                        int kind = br.ReadInt32();
                        if (kind == 106)
                        {
                            textBoxChattingList.AppendText(NickName + "님이 클로버로 바꾸었습니다!!" + Environment.NewLine);
                        }
                        else if (kind == 206)
                        {
                            textBoxChattingList.AppendText(NickName + "님이 다이아로 바꾸었습니다!!" + Environment.NewLine);
                        }
                        else if (kind == 306)
                        {
                            textBoxChattingList.AppendText(NickName + "님이 하트로 바꾸었습니다!!" + Environment.NewLine);
                        }
                        else if (kind == 406)
                        {
                            textBoxChattingList.AppendText(NickName + "님이 스페이스로 바꾸었습니다!!" + Environment.NewLine);
                        }
                        break;
                    case Command.EnableOneCardButton:
                        NickName = br.ReadString();
                        Game.EnableOneCardButton(NickName);
                        break;
                    case Command.DisableOneCardButton:
                        Game.DisableOneCardButton();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
